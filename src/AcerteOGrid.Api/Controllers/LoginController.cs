using AcerteOGrid.Application.Services.Login;
using AcerteOGrid.Communication.Error;
using AcerteOGrid.Communication.Login;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromServices] ILoginService service, [FromBody] LoginRequest request)
        {
            var response = await service.Execute(request);

            return Ok(response);
        }
    }
}
