using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Contracts;
using Store.Common.Validation;
using Store.Services;
using Store.Services.Contracts.Category;
using Store.Web.Framework;

namespace Store.Web.Controllers.Api
{
    /// <summary>Functionality relating to store management.</summary>
    /// <seealso cref="StoreApiController" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/category")]
    public class CategoryController : StoreApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>Delete the specified Category.</summary>
        /// <param name="id">The Id of the Category to be deleted.</param>
        [HttpDelete("{id}", Name = "Category_Delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(UserId, id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>Get all Categories.</summary>
        [HttpGet("", Name = "Categories_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<CategoryDto>))]
        public async Task<ActionResult<IList<CategoryDto>>> GetAsync([FromQuery] PagingOptions pagingOptions)
        {
            var result = await _categoryService.GetAsync(UserId, pagingOptions);

            return Ok(result);
        }

        /// <summary>Get a Category by Id.</summary>
        [HttpGet("{id}", Name = "Category_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<CategoryDto>))]
        public async Task<ActionResult<CategoryDto>> GetAsync(int id)
        {
            var result = await _categoryService.GetAsync(UserId, id);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }


        /// <summary>Creates a Category.</summary>
        /// <param name="body">The Category to be created.</param>
        [HttpPost("{id}", Name = "Category_Post")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CategoryDto>> PostAsync(CategoryDto body)
        {
            var result = await _categoryService.AddAsync(UserId, body);

            if (result == null)
            {
                return BadRequest();
            }

            return Created($"{HttpContext.Request.Path}/{result.Id}", result);
        }

        /// <summary>Updates a Category.</summary>
        /// <returns></returns>
        [HttpPut("{id}", Name = "Category_Put")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CategoryDto>> PutAsync(int id, CategoryDto body)
        {
            ValidationHelper.Validate(body.Id == id, nameof(body.Id), ValidationHelper.KeyDoesNotMatchRoute);

            var result = await _categoryService.UpdateAsync(UserId, body);

            return Ok(result);
        }
    }
}
