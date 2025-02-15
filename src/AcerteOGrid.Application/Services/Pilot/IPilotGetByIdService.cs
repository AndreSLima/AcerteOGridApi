using AcerteOGrid.Communication.Pilot;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotGetByIdService
    {
        Task<PilotResponse> Execute(int id);
    }
}
