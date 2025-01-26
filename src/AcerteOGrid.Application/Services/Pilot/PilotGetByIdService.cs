using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Domain.Repositories.Pilot;
using AcerteOGrid.Exception;
using AcerteOGrid.Exception.ExceptionsBase;
using AutoMapper;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotGetByIdService : IPilotGetByIdService
    {
        private readonly IPilotReadOnlyRespository _repository;
        private readonly IMapper _mapper;

        public PilotGetByIdService(IPilotReadOnlyRespository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponsePilotJson> Execute(int id)
        {
            var result = await _repository.GetById(id);

            if (result is null)
            {
                throw new NotFoundException(ResourceErrorMessages.PILOT_NOT_FOUND);
            }

            return _mapper.Map<ResponsePilotJson>(result);
        }
    }
}
