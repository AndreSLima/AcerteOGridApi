using AcerteOGrid.Communication.Pilot.Response;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotGetByIdService
    {
        Task<ResponsePilotJson> Execute(int id);
    }
}
