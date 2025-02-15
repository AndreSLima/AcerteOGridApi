using AcerteOGrid.Communication.Pilot;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotInsertService
    {
        Task<PilotResponse> Execute(PilotRequestInsert request);
    }
}
