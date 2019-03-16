using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Contracts;
using Store.Common.Validation;
using Store.Services;
using Store.Services.Contracts.Order;
using Store.Web.Framework;

namespace Store.Web.Controllers.Api
{
    /// <summary>Functionality relating to store management.</summary>
    /// <seealso cref="StoreApiController" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/order")]
    public class OrderController : StoreApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>Delete the specified Order.</summary>
        /// <param name="id">The Id of the Order to be deleted.</param>
        [HttpDelete("{id}", Name = "Order_Delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _orderService.DeleteAsync(UserId, id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>Get all Orders.</summary>
        [HttpGet("", Name = "Orders_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<OrderDto>))]
        public async Task<ActionResult<IList<OrderDto>>> GetAsync([FromQuery] PagingOptions pagingOptions)
        {
            var result = await _orderService.GetAsync(UserId, pagingOptions);

            return Ok(result);
        }

        /// <summary>Get a an Order by Id.</summary>
        [HttpGet("{id}", Name = "Order_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<OrderDto>))]
        public async Task<ActionResult<OrderDto>> GetAsync(int id)
        {
            var result = await _orderService.GetAsync(UserId, id);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }


        /// <summary>Creates an Order.</summary>
        /// <param name="body">The Order to be created.</param>
        [HttpPost("{id}", Name = "Order_Post")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<OrderDto>> PostAsync(OrderDto body)
        {
            var result = await _orderService.AddAsync(UserId, body);

            if (result == null)
            {
                return BadRequest();
            }

            return Created($"{HttpContext.Request.Path}/{result.Id}", result);
        }

        /// <summary>Updates an application.</summary>
        /// <returns></returns>
        [HttpPut("{id}", Name = "Order_Put")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<OrderDto>> PutAsync(int id, OrderDto body)
        {
            ValidationHelper.Validate(body.Id == id, nameof(body.Id), ValidationHelper.KeyDoesNotMatchRoute);

            var result = await _orderService.UpdateAsync(UserId, body);

            return Ok(result);
        }
    }
}
