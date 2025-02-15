using AcerteOGrid.Communication.Pilot;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotGetAllService
    {
        Task<List<PilotResponse>> Execute();
    }
}
