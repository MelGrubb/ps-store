using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Contracts;
using Store.Common.Validation;
using Store.Services;
using Store.Services.Contracts.Address;
using Store.Web.Framework;

namespace Store.Web.Controllers.Api
{
    /// <summary>Functionality relating to store management.</summary>
    /// <seealso cref="StoreApiController" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/address")]
    public class AddressController : StoreApiController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        /// <summary>Delete the specified Address.</summary>
        /// <param name="id">The Id of the Address to be deleted.</param>
        [HttpDelete("{id}", Name = "Address_Delete")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _addressService.DeleteAsync(UserId, id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>Get all Addresses.</summary>
        [HttpGet("", Name = "Addresses_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<AddressDto>))]
        public async Task<ActionResult<IList<AddressDto>>> GetAsync([FromQuery] PagingOptions pagingOptions)
        {
            var result = await _addressService.GetAsync(UserId, pagingOptions);

            return Ok(result);
        }

        /// <summary>Get a an Address by Id.</summary>
        [HttpGet("{id}", Name = "Address_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<AddressDto>))]
        public async Task<ActionResult<AddressDto>> GetAsync(int id)
        {
            var result = await _addressService.GetAsync(UserId, id);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }


        /// <summary>Creates an Address.</summary>
        /// <param name="body">The Address to be created.</param>
        [HttpPost("{id}", Name = "Address_Post")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<AddressDto>> PostAsync(AddressDto body)
        {
            var result = await _addressService.AddAsync(UserId, body);

            if (result == null)
            {
                return BadRequest();
            }

            return Created($"{HttpContext.Request.Path}/{result.Id}", result);
        }

        /// <summary>Updates an application.</summary>
        /// <returns></returns>
        [HttpPut("{id}", Name = "Address_Put")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<AddressDto>> PutAsync(int id, AddressDto body)
        {
            ValidationHelper.Validate(body.Id == id, nameof(body.Id), ValidationHelper.KeyDoesNotMatchRoute);

            var result = await _addressService.UpdateAsync(UserId, body);

            return Ok(result);
        }
    }
}
