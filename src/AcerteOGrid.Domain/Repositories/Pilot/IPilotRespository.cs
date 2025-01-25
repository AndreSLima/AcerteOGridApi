using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Repositories.Pilot
{
    public interface IPilotRespository
    {
        Task<PilotEntity> Add(PilotEntity pilotEntity);
    }
}
