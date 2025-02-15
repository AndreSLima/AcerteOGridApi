using AcerteOGrid.Communication.Pilot;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Domain.Services.LoggedUser;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;
using AutoMapper;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotUpdateService : ServiceBase<PilotRequestUpdate, PilotResponse>, IPilotUpdateService
    {
        private readonly IPilotUpdateOnlyRespository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PilotUpdateService(IPilotUpdateOnlyRespository repository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedUser loggedUser) : base(loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<PilotResponse> Execute(PilotRequestUpdate request)
        {
            await base.Execute(request);
            Validate(request);

            var entity = await _repository.GetById(Convert.ToInt32(request.Id));

            if (entity is null)
            {
                throw new NotFoundException(ResourceErrorMessages.PILOT_NOT_FOUND);
            }

            _mapper.Map(request, entity);

            entity.UserChange = base.baseLoggedUser!.Id;

            _repository.Update(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<PilotResponse>(entity);
        }

        private void Validate(PilotRequestUpdate request)
        {
            if (!base.UserMaintence())
            {
                throw new UnauthorizedException(ResourceErrorMessages.UNAUTHORIZED);
            }

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
