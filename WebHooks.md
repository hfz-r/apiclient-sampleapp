### WebHooks (how-to)
1. Authenticate your client.
2. WebHook registration:
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
3. 
