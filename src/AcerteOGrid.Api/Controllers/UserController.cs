using AcerteOGrid.Application.Services.User;
using AcerteOGrid.Communication.Error.Response;
using AcerteOGrid.Communication.User.Request;
using AcerteOGrid.Communication.User.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UserInsertResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Insert([FromServices] IUserInsertService service, [FromBody] UserInsertRequestJson request)
        {
            var response = await service.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
