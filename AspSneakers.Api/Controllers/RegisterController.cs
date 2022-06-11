using AspSneakers.Application.UseCases.Commands;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegisterController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        private readonly IRegisterUserCommand _command;

        public RegisterController(UseCaseHandler handler,IRegisterUserCommand command)
        {
            _handler = handler;
            _command = command;
        }
        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ///<remarks>
        ///Sample request:
        ///
        ///     POST /api/register
        ///     {
        ///        "username" : "newuser",            
        ///        "firstname" : "Aleksandar",            
        ///        "lastname" : "Test",            
        ///        "email" : "testuser@gmail.com",            
        ///        "password : "Sifra123!",    
        ///        "address":"New Adress"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">New account successfully created.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserDto dto)
        {
            _handler.HandleCommand(_command, dto);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
