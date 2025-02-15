using AcerteOGrid.Communication.Pilot;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotDeleteService
    {
        Task Execute(int id);
    }
}
