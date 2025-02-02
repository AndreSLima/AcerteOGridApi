using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Exception.ExceptionsBase;
using AcerteOGrid.Exception;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotUpdateService : IPilotUpdateService
    {
        private readonly IPilotUpdateOnlyRespository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PilotUpdateService(IPilotUpdateOnlyRespository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(int id, PilotUpdateRequestJson request)
        {
            Validate(request);

            var pilot = await _repository.GetById(id);

            if (pilot is null)
            {
                throw new NotFoundException(ResourceErrorMessages.PILOT_NOT_FOUND);
            }

            _mapper.Map(request, pilot);

            _repository.Update(pilot);

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
