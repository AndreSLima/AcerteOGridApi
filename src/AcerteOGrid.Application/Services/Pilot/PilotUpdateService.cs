using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Domain.Services.LoggedUser;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;
using AutoMapper;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotUpdateService : IPilotUpdateService
    {
        private readonly IPilotUpdateOnlyRespository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggedUser _loggedUser;

        public PilotUpdateService(IPilotUpdateOnlyRespository repository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedUser loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loggedUser = loggedUser;
        }

        public async Task Execute(int id, PilotUpdateRequestJson request)
        {
            var loggedUser = await _loggedUser.Get();

            Validate(request, loggedUser);

            var entity = await _repository.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(ResourceErrorMessages.PILOT_NOT_FOUND);
            }

            _mapper.Map(request, entity);

            entity.UserChange = loggedUser.Id;

            _repository.Update(entity);

            await _unitOfWork.Commit();
        }

        private void Validate(PilotUpdateRequestJson request, UserEntity user)
        {
            if (!user.UserTypeEntity.Maintenance)
                throw new UnauthorizedException(ResourceErrorMessages.UNAUTHORIZED);

            var validator = new PilotUpdateValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(p => p.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
