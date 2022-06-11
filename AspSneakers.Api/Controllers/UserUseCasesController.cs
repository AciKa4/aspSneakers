using AspSneakers.Application.UseCases.Commands;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUseCasesController : ControllerBase
    {

        private UseCaseHandler _handler;

        public UserUseCasesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        /// <summary>
        /// Search user use cases by email or usecasename.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     GET /api/userusecases?email=admin@gmail.com
        ///
        /// </remarks>
        /// <response code="200">Returns user use cases.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] UserUseCasesSearch search, [FromServices] IGetUserUseCasesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Update user use cases.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     PUT /api/userusecases
        ///     {
        ///         "userId":2,
        ///         "useCaseIds" : [1,2,3,6,10,20]
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Update is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] UserUseCasesDto dto, [FromServices] IUpdateUseCasesCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

    
    }
}
