using AcerteOGrid.Communication.Pilot.Response;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotGetByIdService
    {
        Task<PilotResponseJson> Execute(int id);
    }
}
