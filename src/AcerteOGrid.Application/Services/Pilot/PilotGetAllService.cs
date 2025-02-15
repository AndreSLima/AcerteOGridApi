using AcerteOGrid.Communication.Pilot;
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

        public async Task<List<PilotResponse>> Execute()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<List<PilotResponse>>(result);
        }
    }
}
