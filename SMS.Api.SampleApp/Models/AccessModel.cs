using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Api.SampleApp.Models
{
    public class AccessModel
    {
        public AuthorizationModel AuthorizationModel { get; set; }

        public UserAccessModel UserAccessModel { get; set; }
    }
}