using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Contracts;
using Store.Common.Validation;
using Store.Services;
using Store.Services.Contracts.Product;
using Store.Web.Framework;

namespace Store.Web.Controllers.Api
{
    /// <summary>Functionality relating to store management.</summary>
    /// <seealso cref="StoreApiController" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : StoreApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>Delete the specified Product.</summary>
        /// <param name="id">The Id of the Product to be deleted.</param>
        [HttpDelete("{id}", Name = "Product_Delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(UserId, id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>Get a an Product by Id.</summary>
        [HttpGet("{id}", Name = "Product_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<ProductDto>))]
        public async Task<ActionResult<ProductDto>> GetAsync(int id)
        {
            var result = await _productService.GetAsync(UserId, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>Get all Products.</summary>
        [HttpGet("", Name = "Products_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<ProductDto>))]
        public async Task<ActionResult<IList<ProductDto>>> GetAsync([FromQuery] PagingOptions pagingOptions)
        {
            var result = await _productService.GetAsync(UserId, pagingOptions);

            return Ok(result);
        }

        /// <summary>Creates an Product.</summary>
        /// <param name="body">The Product to be created.</param>
        [HttpPost("{id}", Name = "Product_Post")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductDto>> PostAsync(ProductDto body)
        {
            var result = await _productService.AddAsync(UserId, body);

            if (result == null)
            {
                return BadRequest();
            }

            return Created($"{HttpContext.Request.Path}/{result.Id}", result);
        }

        /// <summary>Updates an application.</summary>
        /// <returns></returns>
        [HttpPut("{id}", Name = "Product_Put")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductDto>> PutAsync(int id, ProductDto body)
        {
            ValidationHelper.Validate(body.Id == id, nameof(body.Id), ValidationHelper.KeyDoesNotMatchRoute);

            var result = await _productService.UpdateAsync(UserId, body);

            return Ok(result);
        }
    }
}
