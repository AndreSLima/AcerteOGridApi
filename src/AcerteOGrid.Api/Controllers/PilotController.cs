using AcerteOGrid.Communication.Requests.Pilot;
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
            return Created();
        }
    }
}
