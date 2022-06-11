using AspSneakers.Application.UseCases.Commands.Orders;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries.Orders;
using AspSneakers.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspSneakers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private UseCaseHandler _handler;

        public OrdersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Create new order.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     POST /api/orders
        ///     {
        ///        "userId":1,
        ///        "orderlines":
        ///        [
        ///          {
        ///             "productId":1,
        ///             "number":38,
        ///             "quantity":2
        ///          }    
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Order is successfully created.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto dto, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }


        /// <summary>
        /// Search orders by userId.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <remarks>
        ///Sample request:
        ///
        ///     GET /api/orders?userid=1
        ///     
        ///
        /// </remarks>
        /// <response code="200">Returns user orders.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Server error.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }
    }
}
