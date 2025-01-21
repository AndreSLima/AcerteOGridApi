using AcerteOGrid.Application.Services.Pilot;
using AcerteOGrid.Communication.Pilot.Request;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] ResquestRegisterPilotJson request)
        {
            var service = new PilotRegisterService();
            var response = service.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
