using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Framework
{
    [ApiController]
    [Produces("application/json", "application/xml")]
    public abstract class StoreApiController : Controller
    {
        // Fake user Id for now, there are so many ways to do this, and it's out of scope for this demo
        protected int UserId => 1;
    }
}
