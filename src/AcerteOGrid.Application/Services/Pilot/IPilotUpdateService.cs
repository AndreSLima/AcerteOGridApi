using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotUpdateService
    {
        Task Execute(int id, RequestUpdatePilotJson request);
    }
}
