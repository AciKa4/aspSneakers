using AspSneakers.Application.UseCases.Commands.Products;
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
    public class PriceProductsController : ControllerBase
    {
        
        private UseCaseHandler _handler;

        public PriceProductsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        /// <summary>
        /// Create new price for product.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     POST /api/priceproducts
        ///     {
        ///         "productId": 3,
        ///         "price": 200
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Price is successfully created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] PriceProductDto dto, [FromServices] ICreatePriceProductCommand command)
        {

            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

      
        /// <summary>
        /// Delete price for product by sending productId.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <remarks>
        ///Sample request:
        ///
        ///     PATCH /api/priceproducts/2
        ///
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromRoute] PriceProductDto dto, [FromServices] IDeletePriceProductCommand command)
        {
            dto.ProductId = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
