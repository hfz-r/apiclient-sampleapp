using Newtonsoft.Json;
using SMS.Api.SampleApp.Managers;
using SMS.Api.SampleApp.Models;
using SMS.Api.SampleApp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SMS.Api.SampleApp.Controllers
{
    public class AuthorizationController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View("~/Views/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Submit(UserAccessModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var authorizationManager = new AuthorizationManager(model.ClientId, model.ClientSecret, model.ServerUrl);

                    var redirectUrl = Url.RouteUrl("GetAccessToken", null, Request.Url.Scheme);

                    if (redirectUrl != model.RedirectUrl)
                    {
                        return BadRequest();
                    }

                    Session["clientId"] = model.ClientId;
                    Session["clientSecret"] = model.ClientSecret;
                    Session["serverUrl"] = model.ServerUrl;
                    Session["redirectUrl"] = redirectUrl;

                    // This should not be saved anywhere.
                    var state = Guid.NewGuid();
                    Session["state"] = state;

                    string authUrl = authorizationManager.BuildAuthUrl(redirectUrl, new string[] { "sms_api" }, state.ToString());

                    return Redirect(authUrl);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAccessToken(string code, string state, string error, string errorDescription)
        {
            if (ModelState.IsValid && !string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(state))
            {
                if (state != Session["state"].ToString())
                {
                    return BadRequest();
                }

                var model = new AccessModel();

                try
                {
                    string clientId = Session["clientId"].ToString();
                    string clientSecret = Session["clientSecret"].ToString();
                    string serverUrl = Session["serverUrl"].ToString();
                    string redirectUrl = Session["redirectUrl"].ToString();

                    var authParameters = new AuthParameters()
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret,
                        ServerUrl = serverUrl,
                        RedirectUrl = redirectUrl,
                        GrantType = "authorization_code",
                        Code = code
                    };

                    var authorizationManager = new AuthorizationManager(authParameters.ClientId, authParameters.ClientSecret, authParameters.ServerUrl);

                    string responseJson = authorizationManager.GetAuthorizationData(authParameters);

                    AuthorizationModel authorizationModel = JsonConvert.DeserializeObject<AuthorizationModel>(responseJson);

                    model.AuthorizationModel = authorizationModel;
                    model.UserAccessModel = new UserAccessModel()
                    {
                        ClientId = clientId,
                        ClientSecret = clientSecret,
                        ServerUrl = serverUrl,
                        RedirectUrl = redirectUrl
                    };

                    Session["accessToken"] = authorizationModel.AccessToken;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return View("~/Views/AccessToken.cshtml", model);
            }

            return BadRequest();
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult RefreshAccessToken(string refreshToken, string clientId, string clientSecret, string serverUrl)
        {
            string json = string.Empty;

            if (ModelState.IsValid &&
              !string.IsNullOrEmpty(refreshToken) &&
              !string.IsNullOrEmpty(clientId) &&
              !string.IsNullOrEmpty(serverUrl) &&
              !string.IsNullOrEmpty(clientSecret))
            {
                var model = new AccessModel();

                try
                {
                    var authParameters = new AuthParameters()
                    {
                        ClientId = clientId,
                        ServerUrl = serverUrl,
                        RefreshToken = refreshToken,
                        GrantType = "refresh_token",
                        ClientSecret = clientSecret
                    };

                    var authorizationManager = new AuthorizationManager(authParameters.ClientId, authParameters.ClientSecret, authParameters.ServerUrl);

                    string responseJson = authorizationManager.RefreshAuthorizationData(authParameters);

                    AuthorizationModel authorizationModel = JsonConvert.DeserializeObject<AuthorizationModel>(responseJson);

                    model.AuthorizationModel = authorizationModel;
                    model.UserAccessModel = new UserAccessModel()
                    {
                        ClientId = clientId,
                        ServerUrl = serverUrl
                    };

                    TempData["accessToken"] = authorizationModel.AccessToken;
                    TempData["serverUrl"] = serverUrl;
                }
                catch (Exception ex)
                {
                    json = string.Format("error: '{0}'", ex.Message);

                    return Json(json, JsonRequestBehavior.AllowGet);
                }

                json = JsonConvert.SerializeObject(model.AuthorizationModel);
            }
            else
            {
                json = "error: 'something went wrong'";
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        private ActionResult BadRequest(string message = "Bad Request")
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
        }
    }
}