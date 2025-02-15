using AcerteOGrid.Application.Services.Pilot;
using AcerteOGrid.Communication.Error;
using AcerteOGrid.Communication.Pilot;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcerteOGrid.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(PilotResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllPilots([FromServices] IPilotGetAllService service)
        {
            var response = await service.Execute();

            if (response.Count > 0)
                return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PilotResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPilot([FromServices] IPilotGetByIdService service, [FromRoute] int id)
        {
            var response = await service.Execute(id);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PilotResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> PostPilot([FromServices] IPilotInsertService service, [FromBody] PilotRequestInsert request)
        {
            var response = await service.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(PilotResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> PutPilot([FromServices] IPilotUpdateService service, [FromRoute] int id, [FromBody] PilotRequestUpdate request)
        {
            request.Id = id;

            var response = await service.Execute(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> DeletePilot([FromServices] IPilotDeleteService service, [FromRoute] int id)
        {
            await service.Execute(id);

            return NoContent();
        }
    }
}
