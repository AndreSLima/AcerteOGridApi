using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Repositories.Pilot
{
    public interface IPilotWriteOnlyRespository
    {
        Task<PilotEntity> Insert(PilotEntity pilotEntity);

        Task<bool> Delete(int id);
    }
}
