using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotInsertService
    {
        Task<ResponsePilotJson> Execute(RequestInsertPilotJson request);
    }
}
