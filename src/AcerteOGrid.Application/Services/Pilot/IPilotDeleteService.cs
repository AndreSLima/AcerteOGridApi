using AcerteOGrid.Communication.Pilot.Response;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotDeleteService
    {
        Task Execute(int id);
    }
}
