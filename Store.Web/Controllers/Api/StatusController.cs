using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Services;
using Store.Services.Contracts.Status;
using Store.Web.Framework;

namespace Store.Web.Controllers.Api
{
    /// <summary>Functionality relating to API status reporting.</summary>
    /// <seealso cref="StoreApiController" />
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/status")]
    public class StatusController : StoreApiController
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        /// <summary>Get a an Address by Id.</summary>
        [HttpGet(Name = "Status_Get")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ActionResult<StatusGetResponse>))]
        public async Task<StatusGetResponse> GetAsync()
        {
            var result = await _statusService.GetAsync();

            return result;
        }
    }
}
