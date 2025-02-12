using AcerteOGrid.Domain.Entities;
using AcerteOGrid.Domain.Repositories.Pilot;
using Microsoft.EntityFrameworkCore;

namespace AcerteOGrid.Infrastructure.DataAccess.Repositories
{
    internal class PilotRepository : IPilotReadOnlyRespository, IPilotWriteOnlyRespository, IPilotUpdateOnlyRespository
    {
        private readonly AcerteOGridDbContext _dbcontext;

        public PilotRepository(AcerteOGridDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<PilotEntity>> GetAll()
        {
            return await _dbcontext.AOG_TB_PILOTO.AsNoTracking().ToListAsync();
        }

        async Task<PilotEntity?> IPilotReadOnlyRespository.GetById(int id)
        {
            return await _dbcontext.AOG_TB_PILOTO.AsNoTracking().FirstOrDefaultAsync(pilot => pilot.Id == id);
        }

        async Task<PilotEntity?> IPilotUpdateOnlyRespository.GetById(int id)
        {
            return await _dbcontext.AOG_TB_PILOTO.FirstOrDefaultAsync(pilot => pilot.Id == id);
        }

        public async Task<PilotEntity> Insert(PilotEntity pilotEntity)
        {
            await _dbcontext.AOG_TB_PILOTO.AddAsync(pilotEntity);

            return pilotEntity;
        }

        public void Update(PilotEntity pilotEntity)
        {
            _dbcontext.AOG_TB_PILOTO.Update(pilotEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _dbcontext.AOG_TB_PILOTO.FirstOrDefaultAsync(pilot => pilot.Id == id);
            if (result is null)
            {
                return false;
            }

            _dbcontext.AOG_TB_PILOTO.Remove(result);

            return true;
        }
    }
}
