using AspSneakers.Application.UseCases.Commands.Categories;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries.Categories;
using AspSneakers.Application.UseCases.Queries.Category;
using AspSneakers.DataAccess;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {

        private UseCaseHandler _handler;

        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Search categories by keyword.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/categories
        ///  
        ///
        /// </remarks>
        /// <response code="200">Returns categories.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery]BasePagedSearch search, [FromServices] IGetCategoriesQuery query)
        {

            return Ok(_handler.HandleQuery(query, search));
        }


        /// <summary>
        /// Search category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/categories/3
        ///  
        ///
        /// </remarks>
        /// <response code="200">Returns category.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindCategoryQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }




        /// <summary>
        /// Create new category.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// /// Sample request:
        ///
        ///     POST /api/categories
        ///     {
        ///        "name" : "name of new category"            
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Category is successfully created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDto dto, [FromServices] ICreateCategoryCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Update category.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// 
        /// /// Sample request:
        ///
        ///     PUT /api/categories/2
        ///     {
        ///        name : "new name for category"            
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Update is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto, [FromServices] IUpdateCategoryCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        /// <summary>
        /// Delete category.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// /// Sample request:
        ///
        ///     PATCH /api/categories/1
        ///
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromServices] IDeleteCategoryCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }

    }
}
