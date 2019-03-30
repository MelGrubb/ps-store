using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Common.Contracts;
using Store.Services;
using Store.Services.Contracts.Country;
using Store.Web.Framework;

namespace Store.Web.Controllers.Api
{
    /// <summary>Functionality relating to store management.</summary>
    /// <seealso cref="StoreApiController" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/country")]
    public class CountryController : StoreApiController
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>Get all Countries.</summary>
        [HttpGet("", Name = "Countries_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<CountryDto>))]
        public async Task<ActionResult<IList<CountryDto>>> GetAsync([FromQuery] PagingOptions pagingOptions)
        {
            var result = await _countryService.GetAsync(UserId, pagingOptions);

            return Ok(result);
        }

        /// <summary>Get a an Country by Id.</summary>
        [HttpGet("{id}", Name = "Country_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<CountryDto>))]
        public async Task<ActionResult<CountryDto>> GetAsync(int id)
        {
            var result = await _countryService.GetAsync(UserId, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
