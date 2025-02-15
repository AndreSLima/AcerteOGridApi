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
    public class PilotInsertService : ServiceBase<PilotRequestInsert, PilotResponse>, IPilotInsertService
    {
        private readonly IPilotWriteOnlyRespository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PilotInsertService(IPilotWriteOnlyRespository repository, IUnitOfWork unitOfWork, IMapper mapper, ILoggedUser loggedUser) : base(loggedUser)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<PilotResponse> Execute(PilotRequestInsert request)
        {
            await base.Execute(request);
            Validate(request);

            var entity = _mapper.Map<PilotEntity>(request);

            entity.UserInclusion = base.baseLoggedUser!.Id;
            entity = await _repository.Insert(entity);

            await _unitOfWork.Commit();

            return _mapper.Map<PilotResponse>(entity);
        }

        private void Validate(PilotRequestInsert request)
        {
            if (!base.UserMaintence())
            {
                throw new UnauthorizedException(ResourceErrorMessages.UNAUTHORIZED);
            }

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
