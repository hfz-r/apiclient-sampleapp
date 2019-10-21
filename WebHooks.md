### WebHooks Documentation

1. Authenticate your client.

2. **Register webhook**: 
    Make a **POST** request to the following route: **/api/webhooks/registrations**
    
    With JSON data:
    
    ```json
    {
        "WebHookUri":"http?s://yourUrl.com/yourApiEndpoint?NoEcho=true",
        "Filters":["users/created", "users/updated", "users/deleted"]
    }
     ```
     
     **NOTE:** If the **NoEcho** parameter is not passed a **GET** request will be made to the **WebHookUri** endpoint,
     passing an **echo** parameter. The endpoint should return the **echo** parameter with a status code 200.
     This is done in order to verify that the endpoint is valid and that it is configured to work with the webhooks.

    Example result:
    ```json
    {
        "Id": "79bc3fe2439e45749c9cf14764d508a9",
        "WebHookUri": "http://localhost:51502/api/webhook?NoEcho=true",
        "Secret": "298abbffb2a0414b9990cf25a59a3aaf",
        "Description": null,
        "IsPaused": false,
        "Filters": [
        "users/created",
        "users/updated",
        "users/deleted"
        ],
        "Headers": {},
        "Properties": {}
    }
     ```
     
3. **Get webhooks events/filters**: 
    Make a **GET** request to the following route: **/api/webhooks/filters**
    
    Example result:
    ```json
    [
        {
            "Name": "users/created",
            "Description": "A user has been created."
        },
        {
            "Name": "users/updated",
            "Description": "A user has been updated."
        },
        {
            "Name": "users/deleted",
            "Description": "A user has been deleted."
        },
        {
            "Name": "devices/created",
            "Description": "A device has been created."
        },
        {
            "Name": "devices/updated",
            "Description": "A device has been updated."
        },
        {
            "Name": "devices/deleted",
            "Description": "A device has been deleted."
        },
        {
            "Name": "items/created",
            "Description": "An item has been created."
        },
        {
            "Name": "items/updated",
            "Description": "An item has been updated."
        },
        {
            "Name": "items/deleted",
            "Description": "An item has been deleted."
        }
    ]
    ```
    
4. **Get all webhooks**: 
    Make a **GET** request to the following route: **/api/webhooks/registrations**
    
    Example result:
    ```json
    [
        {
            "Id": "79bc3fe2439e45749c9cf14764d508a9",
            "WebHookUri": "http://localhost:51502/api/webhook?NoEcho=true",
            "Secret": "298abbffb2a0414b9990cf25a59a3aaf",
            "Description": null,
            "IsPaused": false,
            "Filters": [
                "users/created",
                "users/updated",
                "users/deleted"
            ],
            "Headers": {},
            "Properties": {}
        }
    ]
    ```

5. **Get a specific webhook**: 
    Make a **GET** request to the following route: **/api/webhooks/registrations/{webhookid}**
    
    Example result:
    ```json
    {
        "Id": "79bc3fe2439e45749c9cf14764d508a9",
        "WebHookUri": "http://localhost:51502/api/webhook?NoEcho=true",
        "Secret": "298abbffb2a0414b9990cf25a59a3aaf",
        "Description": null,
        "IsPaused": false,
        "Filters": [
            "users/created",
            "users/updated",
            "users/deleted"
        ],
        "Headers": {},
        "Properties": {}
    }
    ```

6. **Update a webhook**: 
    Make a **PUT** request to the following route: **/api/webhooks/registrations/{webhookid}**
    
    With JSON data:
    
    ```json
    {
        "WebHookUri": "http://localhost:51502/api/webhook?NoEcho=true",
        "Filters": [
            "transaction/created"
        ]
    }
     ```
    
7. **Delete a specific webhook**: 
    Make a **DELETE** request to the following route: **/api/webhooks/registrations/{webhookid}** 
    
8. **Delete all webhooks**: 
    Make a **DELETE** request to the following route: **/api/webhooks/registrations**


### Usage

- [callback/retrieval page](https://github.com/hfz-r/apiclient-sampleapp/blob/master/SMS.Api.SampleApp/Controllers/WebHookController.cs) and its [responded](https://github.com/hfz-r/apiclient-sampleapp/blob/master/webhook-result-sample.json)
    ```cs
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
    ```

- [Postman collection](https://documenter.getpostman.com/view/4900831/S1TSYeDb?version=latest#3b3a56e0-f968-4585-addb-eb4dd3a1ebfb)
