using AspSneakers.Application.UseCases.Commands.Brands;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries.Brand;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {

        private UseCaseHandler _handler;

        public BrandsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Search brands.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/brands
        ///  
        ///
        /// </remarks>
        /// <response code="200">Returns brands.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetBrandsQuery query)
        {
            
            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Create new brand.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        ///  <remarks>
        /// Sample request:
        ///
        ///     POST /api/brands
        ///     {
        ///         "name" : "new brand"
        ///     }
        /// </remarks>
        /// <response code="201">Brand is successfully created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] BrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Update brand.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/brands/3
        ///     {
        ///         "name" : "new name"
        ///     }
        /// </remarks>
        /// <response code="204">Update is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto, [FromServices] IUpdateBrandCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();

        }

        /// <summary>
        /// Delete brand.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/brands/3
        ///     
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromServices] IDeleteBrandCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
