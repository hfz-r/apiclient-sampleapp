using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SMS.Api.AdapterLibrary;
using SMS.Api.SampleApp.Models;

namespace SMS.Api.SampleApp.Controllers
{
    public class WebHookSettingController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/WebHooks/Index.cshtml");
        }

        public ActionResult Subscribe()
        {
            var model = new WebHookRegistration();

            return View("~/Views/WebHooks/Subscribe.cshtml", model);
        }

        [HttpPost]
        public ActionResult Subscribe(WebHookRegistration model)
        {
            if (string.IsNullOrEmpty(model.WebHookUri))
                throw new ArgumentNullException(nameof(model.WebHookUri));

            if (!ModelState.IsValid)
                return View("~/Views/WebHooks/Subscribe.cshtml", model);

            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            var apiClient = new ApiClient(accessToken, serverUrl);
            apiClient.Post("/api/webhooks/registrations", JsonConvert.SerializeObject(model));

            return RedirectToAction("Index");
        }
    }
}