using AspSneakers.Api.DTO;
using AspSneakers.Application.UseCases.Commands.Products;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries.Products;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {

        private UseCaseHandler _handler;

        public ProductsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Search products.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     GET /api/products
        ///
        /// </remarks>
        /// <response code="200">Returns products.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BasePagedSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }




        /// <summary>
        /// Find product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     GET /api/products/2
        ///
        /// </remarks>
        /// <response code="200">Returns product.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindProductQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }


        /// <summary>
        /// Create new product using form-data.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <remarks>
        ///Sample request:
        ///
        ///     POST /api/products
        ///     {
        ///         "name":"new product",
        ///         "image": picture1.jpg,
        ///         "brandId":2,
        ///         "genderId":1,
        ///         "categories[0]":1,
        ///         "categories[1]:2,
        ///         "Price":140,
        ///         "Description":"New description for product."
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Product successfully created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPost]
        public IActionResult Post([FromForm] UploadFileDto dto, [FromServices] ICreateProductCommand command)
        {


            if(dto.Image != null)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(dto.Image.FileName);
                var name = guid + extension;

                if (!SupportedExt.Contains(extension))
                {
                    throw new InvalidOperationException("Invalid extension.");
                }

                var path = Path.Combine("wwwroot", "images", name);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    dto.Image.CopyTo(fileStream);
                }


                dto.ImageFileName = name;
            }

            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        private IEnumerable<string> SupportedExt => new List<string> { ".png", ".jpeg", ".jpg" };


        /// <summary>
        /// Update product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     PUT /api/products
        ///     {
        ///         "name":"new product name",
        ///         "genderId":2,
        ///         "categories[0]":3,
        ///         "categories[1]:5,
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Update is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProductDto dto,[FromServices] IUpdateProductCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        /// <summary>
        /// Delete product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     PATCH /api/products//3
        ///
        /// </remarks>
        /// <response code="204">Delete is successful.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromServices] IDeleteProductCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
