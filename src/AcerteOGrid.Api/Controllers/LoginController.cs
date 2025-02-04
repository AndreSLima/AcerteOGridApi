using AcerteOGrid.Application.Services.Login;
using AcerteOGrid.Communication.Error.Response;
using AcerteOGrid.Communication.Login;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromServices] ILoginService service, [FromBody] LoginRequestJSon request)
        {
            var response = await service.Execute(request);

            return Ok(response);
        }
    }
}
