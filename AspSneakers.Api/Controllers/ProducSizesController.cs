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
    public class ProductSizesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public ProductSizesController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        /// <summary>
        /// Create size for specific product.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     POST /api/productsizes
        ///     {
        ///         "sizeId":7
        ///         "productId":5,
        ///         "stock":10
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Size for product is successfuly created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] ProductSizeDto dto, [FromServices] ICreateProductSizesCommand command)
        {

            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }



        /// <summary>
        /// Update stock for product's size.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     PUT /api/productsizes
        ///     {
        ///         "sizeId":7
        ///         "productId":5,
        ///         "stock":15
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Update is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPut]
        public IActionResult Put([FromBody] ProductSizeDto dto, [FromServices] IUpdateProductSizesCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        /// <summary>
        /// Delete size for product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     DELETE /api/productsizes/1
        ///
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteProductSizeCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
