using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Domain.Services.LoggedUser;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;
using AutoMapper;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotInsertService : IPilotInsertService
    {
        private readonly IPilotWriteOnlyRespository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public PilotInsertService(IPilotWriteOnlyRespository repository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task<PilotResponseJson> Execute(PilotInsertRequestJson request)
        {
            var loggedUser = await _loggedUser.Get();

            Validate(request, loggedUser);

            var entity = _mapper.Map<PilotEntity>(request);

            entity.UserInclusion = loggedUser.Id;
            entity = await _repository.Insert(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<PilotResponseJson>(entity);
        }

        private void Validate(PilotInsertRequestJson request, UserEntity user)
        {
            if (!user.UserTypeEntity.Maintenance)
                throw new UnauthorizedException(ResourceErrorMessages.UNAUTHORIZED);

            var validator = new PilotInsertValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(p => p.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
