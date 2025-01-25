using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories.Pilot;

namespace AcerteOGrid.Infrastructure.DataAccess.Repositories
{
    internal class PilotRepository : IPilotRespository
    {
        private readonly AcerteOGridDbContex _dbcontext;

        public PilotRepository(AcerteOGridDbContex dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<PilotEntity> Add(PilotEntity pilotEntity)
        {
            await _dbcontext.AOG_TB_PILOTO.AddAsync(pilotEntity);

            return pilotEntity;
        }
    }
}
