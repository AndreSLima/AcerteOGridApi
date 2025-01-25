using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;

namespace AcerteOGrid.Application.Services.Pilot
{
    public interface IPilotRegisterService
    {
        Task<ResponseRegisterPilotJson> Execute(ResquestRegisterPilotJson request);
    }
}
