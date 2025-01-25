using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Exception.ExceptionsBase;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotRegisterService : IPilotRegisterService
    {
        private readonly IPilotRespository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PilotRegisterService(IPilotRespository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterPilotJson> Execute(ResquestRegisterPilotJson request)
        {
            Validate(request);

            var entity = new PilotEntity
            {
                Name = request.Name,
                ShortName = request.ShortName,
                DateOfBirth = request.DateOfBirth,
                DateOfDeath = request.DateOfDeath,
                GenderType = request.GenderType,
            };

            entity = await _repository.Add(entity);
            await _unitOfWork.Commit();

            var response = new ResponseRegisterPilotJson
            {
                Id = entity.Id,
                Name = entity.Name,
                ShortName = entity.ShortName,
                DateOfBirth = entity.DateOfBirth,
                DateOfDeath = entity.DateOfDeath,
                GenderType = entity.GenderType,
            };

            return response;
        }

        private void Validate(ResquestRegisterPilotJson request)
        {
            var validator = new PilotRegisterValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(p => p.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
