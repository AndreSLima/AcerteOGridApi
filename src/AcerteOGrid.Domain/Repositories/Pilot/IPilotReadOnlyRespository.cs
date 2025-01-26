using AcerteOGrid.Domain.Entities;

namespace AcerteOGrid.Domain.Repositories.Pilot
{
    public interface IPilotReadOnlyRespository
    {
        Task<List<PilotEntity>> GetAll();

        Task<PilotEntity?> GetById(int id);
    }
}
