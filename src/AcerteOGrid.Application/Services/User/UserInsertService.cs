using AcerteOGrid.Communication.User.Request;
using AcerteOGrid.Communication.User.Response;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.User;
using AcerteOGrid.Domain.Security.Cryptography;
using AcerteOGrid.Domain.Services.LoggedUser;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;
using AutoMapper;
using FluentValidation.Results;

namespace AcerteOGrid.Application.Services.User
{
    public class UserInsertService : ServiceBase<UserInsertRequestJson>, IUserInsertService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly ILoggedUser _loggedUser;

        public UserInsertService(IMapper mapper, IUnitOfWork unitOfWork, IUserReadOnlyRepository userReadOnlyRepository, IUserWriteOnlyRepository userWriteOnlyRepository, IPasswordEncripter passwordEncripter, ILoggedUser loggedUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _passwordEncripter = passwordEncripter;
            _loggedUser = loggedUser;
        }

        public async Task<UserInsertResponseJson> Execute(UserInsertRequestJson request)
        {
            var loggedUser = await _loggedUser.Get();

            Validate(request, loggedUser);

            var entity = _mapper.Map<UserEntity>(request);

            entity.Password = _passwordEncripter.Encrypt(request.Password);
            entity.Identifier = Guid.NewGuid();
            entity.UserInclusion = loggedUser.Id;

            await _userWriteOnlyRepository.Insert(entity);
            await _unitOfWork.Commit();

            return new UserInsertResponseJson
            {
                Name = entity.Name,
                Email = entity.Email
            };
        }

        protected override void Validate(UserInsertRequestJson request, UserEntity user)
        {
            base.Validate(request, user);

            var result = new UserInsertValidator().Validate(request);

            var emailExists = _userReadOnlyRepository.ExistsActiveUserWithEmail(request.Email);
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
