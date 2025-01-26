using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Repositories.Pilot
{
    public interface IPilotUpdateOnlyRespository
    {
        Task<PilotEntity?> GetById(int id);
        
        void Update(PilotEntity pilotEntity);
    }
}
