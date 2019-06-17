using System.Collections.Generic;

namespace SMS.Api.SampleApp.Models
{
    public class WebHookResponse
    {
        public string Id { get; set; }

        public int Attempt { get; set; }

        public IList<Notifications> Notifications { get; set; }

        public string WebHookId { get; set; }
    }

    public class Notifications
    {
        public string Action { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}