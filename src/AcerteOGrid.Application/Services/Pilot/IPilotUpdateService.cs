using AcerteOGrid.Communication.Pilot;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotUpdateService
    {
        Task<PilotResponse> Execute(PilotRequestUpdate request);
    }
}
