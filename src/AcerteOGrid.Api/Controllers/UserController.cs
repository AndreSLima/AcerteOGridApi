using AcerteOGrid.Application.Services.User;
using AcerteOGrid.Communication.Error;
using AcerteOGrid.Communication.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(UserResponseInsert), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Insert([FromServices] IUserInsertService service, [FromBody] UserRequestInsert request)
        {
            var response = await service.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
