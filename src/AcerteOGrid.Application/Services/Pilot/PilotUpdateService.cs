using AcerteOGrid.Communication.Pilot.Request;
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
            Validate(request);

            var entity = await _repository.GetById(id);

            if (entity is null)
            {
                throw new NotFoundException(ResourceErrorMessages.PILOT_NOT_FOUND);
            }

            _mapper.Map(request, entity);

            var loggedUser = await _loggedUser.Get();
            entity.UserChange = loggedUser.Id;

            _repository.Update(entity);

            await _unitOfWork.Commit();
        }

        private void Validate(PilotUpdateRequestJson request)
        {
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
