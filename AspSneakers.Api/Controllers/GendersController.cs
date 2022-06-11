using AspSneakers.Application.UseCases.Commands.Genders;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries.Genders;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GendersController : ControllerBase
    {

        private UseCaseHandler _handler;

        public GendersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Search genders.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     GET /api/genders
        ///
        /// </remarks>
        /// <response code="200">Returns genders.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetGendersQuery query)
        {

            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     POST /api/genders
        ///     {
        ///        "name" : "name of new gender"            
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Gender is successfully created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] GenderDto dto, [FromServices] ICreateGenderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        /// <summary>
        /// Update gender.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     PUT /api/genders/1
        ///     {
        ///        "name" : "new name"            
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Update is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenderDto dto, [FromServices] IUpdateGenderCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }


        /// <summary>
        /// Delete gender.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     PATCH /api/genders/1
        ///
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromServices] IDeleteGenderCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
