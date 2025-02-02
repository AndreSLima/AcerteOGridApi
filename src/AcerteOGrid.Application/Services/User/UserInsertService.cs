using AcerteOGrid.Communication.User.Request;
using AcerteOGrid.Communication.User.Response;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.User;
using AcerteOGrid.Domain.Security.Cryptography;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;
using AutoMapper;
using FluentValidation.Results;

namespace AcerteOGrid.Application.Services.User
{
    public class UserInsertService : IUserInsertService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IPasswordEncripter _passwordEncripter;

        public UserInsertService(IMapper mapper, IUnitOfWork unitOfWork, IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository, IPasswordEncripter passwordEncripter)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<UserInsertResponseJson> Execute(UserInsertRequestJson request)
        {
            await Validate(request);

            var user = _mapper.Map<UserEntity>(request);
            user.Password = _passwordEncripter.Encrypt(request.Password);
            user.Identifier = Guid.NewGuid();

            await _userWriteOnlyRepository.Insert(user);
            await _unitOfWork.Commit();

            return new UserInsertResponseJson
            {
                Name = user.Name,
                Token = ""
            };
        }

        private async Task Validate(UserInsertRequestJson request)
        {
            var result = new UserInsertValidator().Validate(request);

            var emailExists = await _userReadOnlyRepository.ExistsActiveUserWithEmail(request.Email);
            if (emailExists)
            {
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTRED));
            }

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
