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
        public async Task<IActionResult> Register([FromServices] IPilotRegisterService service, [FromBody] ResquestRegisterPilotJson request)
        {
            var response = await service.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
