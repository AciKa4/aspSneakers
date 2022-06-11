using AspSneakers.Application.UseCases.Commands.Users;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries.Users;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {

        private UseCaseHandler _handler;

        public UsersController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        /// <summary>
        /// Search users.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     GET /api/users
        ///
        /// </remarks>
        /// <response code="200">Returns users.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetUsersQuery query)
        {

            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <remarks>
        ///Sample request:
        ///
        ///     PUT /api/users
        ///     {
        ///         "username" : "newusername",
        ///         "firstname" : "Aleks",
        ///         "lastname" : "Testt"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Update is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto dto, [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
        }

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     PATCH /api/users/1
        ///
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
