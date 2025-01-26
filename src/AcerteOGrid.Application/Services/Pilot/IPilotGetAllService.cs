using AcerteOGrid.Communication.Pilot.Response;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotGetAllService
    {
        Task<List<ResponsePilotJson>> Execute();
    }
}
