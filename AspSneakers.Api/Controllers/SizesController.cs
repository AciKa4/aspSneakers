using AspSneakers.Application.UseCases.Commands.Categories;
using AspSneakers.Application.UseCases.Commands.Sizes;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SizesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public SizesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Create new size.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     POST /api/sizes
        ///     {
        ///        "number" : 45            
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Size is successfully created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] SizeDto dto, [FromServices] ICreateSizeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        /// <summary>
        /// Delete size.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     DELETE /api/sizes/4
        ///
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteSizeCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();

        }
    }
}
