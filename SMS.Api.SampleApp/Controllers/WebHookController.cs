﻿using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SMS.Api.SampleApp.Controllers
{
    [RoutePrefix("api/webhook")]
    public class WebhookController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get(string echo)
        {
            Console.WriteLine("Received echo request for validation of the registration");

            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(echo, Encoding.UTF8, "text/plain")
            };
            return resp;
        }

        [HttpPost]
        [Route("")]
        public void Post(object message)
        {
            Console.WriteLine($"Received webhook: {message}");
        }
    }
}