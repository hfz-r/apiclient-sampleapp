using System.Web.Mvc;

namespace SMS.Api.SampleApp.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult Error()
        {
            return View("~/Views/Error.cshtml");
        }
    }
}