using AcerteOGrid.Application.Services.Pilot;
using AcerteOGrid.Communication.Error.Response;
using AcerteOGrid.Communication.Pilot.Request;
using AcerteOGrid.Communication.Pilot.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(PilotResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllPilots([FromServices] IPilotGetAllService service)
        {
            var response = await service.Execute();

            if (response.Count > 0)
                return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PilotResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPilot([FromServices] IPilotGetByIdService service, [FromRoute] int id)
        {
            var response = await service.Execute(id);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PilotResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> PostPilot([FromServices] IPilotInsertService service, [FromBody] PilotInsertRequestJson request)
        {
            var response = await service.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> PutPilot([FromServices] IPilotUpdateService service, [FromRoute] int id, [FromBody] PilotUpdateRequestJson request)
        {
            await service.Execute(id, request);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> DeletePilot([FromServices] IPilotDeleteService service, [FromRoute] int id)
        {
            await service.Execute(id);

            return NoContent();
        }
    }
}
