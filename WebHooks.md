### WebHooks (how-to)
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
    
    The JSON should contain at least the WebHook Id, WebHookUri and Filters.
    
7. **Delete a specific webHook**:
    Make a **DELETE** request to the following route: **/api/webhooks/registrations/{webhookid}** 
    
8. **Delete all Webhooks**
    Make a **DELETE** request to the following route: **/api/webhooks/registrations**
   
