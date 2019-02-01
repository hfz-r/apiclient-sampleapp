using Newtonsoft.Json;
using SMS.Api.AdapterLibrary;
using SMS.Api.SampleApp.DTOs;
using System.Linq;
using System.Web.Mvc;

namespace SMS.Api.SampleApp.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult GetUsers()
        {
            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            var apiClient = new ApiClient(accessToken, serverUrl);

            string jsonUrl = $"/api/users?fields=id,first_name,last_name";
            object usersData = apiClient.Get(jsonUrl);

            var usersRootObject = JsonConvert.DeserializeObject<UsersRootObject>(usersData.ToString());

            var users = usersRootObject.Users.Where(user =>
                !string.IsNullOrEmpty(user.FirstName) || !string.IsNullOrEmpty(user.LastName));

            return View("~/Views/Users.cshtml", users);
        }

        public ActionResult UpdateUser(int userId)
        {
            var accessToken = (Session["accessToken"] ?? TempData["accessToken"]).ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"]).ToString();

            var apiClient = new ApiClient(accessToken, serverUrl);

            string jsonUrl = $"/api/users/{userId}";

            var userToUpdate = new {user = new {last_name = ""}};
            string userJson = JsonConvert.SerializeObject(userToUpdate);

            apiClient.Put(jsonUrl, userJson);

            return RedirectToAction("GetUsers");
        }
    }
}