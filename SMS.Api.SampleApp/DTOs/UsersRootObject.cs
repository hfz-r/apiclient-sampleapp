using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Api.SampleApp.DTOs
{
    public class UsersRootObject
    {
        [JsonProperty("users")]
        public List<UserApi> Users { get; set; }
    }
}