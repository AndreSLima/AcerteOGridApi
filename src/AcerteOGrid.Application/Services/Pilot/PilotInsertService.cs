using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Exception.ExceptionsBase;
using AutoMapper;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotInsertService : IPilotInsertService
    {
        private readonly IPilotWriteOnlyRespository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PilotInsertService(IPilotWriteOnlyRespository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponsePilotJson> Execute(RequestInsertPilotJson request)
        {
            Validate(request);

            var entity = _mapper.Map<PilotEntity>(request);

            entity = await _repository.Insert(entity);
            await _unitOfWork.Commit();
                        
            return _mapper.Map<ResponsePilotJson>(entity);
        }

        private void Validate(RequestInsertPilotJson request)
        {
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
