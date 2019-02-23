using Microsoft.AspNetCore.Mvc;
using Store.Web.Framework;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Web.Controllers.Mvc
{
    public class HomeController : StoreMvcController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
