using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Api.SampleApp.Models
{
    public class UserAccessModel
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ServerUrl { get; set; }

        public string RedirectUrl { get; set; }
    }
}