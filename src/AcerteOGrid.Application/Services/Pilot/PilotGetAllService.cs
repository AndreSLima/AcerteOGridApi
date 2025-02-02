using AcerteOGrid.Communication.Pilot.Response;
using AcerteOGrid.Domain.Repositories.Pilot;
using AutoMapper;

namespace AcerteOGrid.Application.Services.Pilot
{
    public class PilotGetAllService : IPilotGetAllService
    {
        private readonly IPilotReadOnlyRespository _repository;
        private readonly IMapper _mapper;

        public PilotGetAllService(IPilotReadOnlyRespository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PilotResponseJson>> Execute()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<List<PilotResponseJson>>(result);
        }
    }
}
