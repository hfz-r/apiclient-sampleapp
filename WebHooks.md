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

- upon succesful hookups, inspect your [retrieval controller](https://github.com/hfz-r/apiclient-sampleapp/blob/master/SMS.Api.SampleApp/Controllers/WebHookController.cs) to view your subscribed events in details.
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

- sample details
```json
{
  "Id": "0c214c640ed6430280846de4239e19fb",
  "Attempt": 1,
  "Properties": {},
  "Notifications": [
    {
      "Action": "users/updated",
      "UserGuid": "3bb00700-7e91-4b98-a624-c5fb32f99685",
      "Username": "hafiz",
      "Email": "hafiz@haha.com",
      "Password": null,
      "LoginToken": false,
      "PasswordLastModified": null,
      "UserPassword": {
        "password": "hafiz007",
        "created_on": "2019-06-13T04:07:37.5258872",
        "password_format": "Clear",
        "id": 1
      },
      "FirstName": "Brian",
      "LastName": "Eno",
      "DateOfBirth": null,
      "Gender": null,
      "Barcode": null,
      "Active": true,
      "Deleted": false,
      "IsSystemAccount": true,
      "SystemName": null,
      "LastIpAddress": "127.0.0.1",
      "CreatedOnUtc": "2019-06-13T04:07:37.0165763",
      "LastLoginDateUtc": "2019-06-17T04:10:13.2716798",
      "LastActivityDateUtc": "2019-06-17T06:00:53.985828Z",
      "RegisteredInTenantId": 1,
      "RoleIds": [
        1,
        3
      ],
      "StoreIds": [],
      "Roles": [
        {
          "name": "SysAdmin",
          "active": true,
          "is_system_role": true,
          "system_name": "SysAdmin",
          "permissions": [
            {
              "name": "(Web) Access panel",
              "system_name": "AccessPanel",
              "category": "Standard",
              "id": 1
            },
            {
              "name": "(Web) Manage Users",
              "system_name": "ManageUsers",
              "category": "User Management",
              "id": 2
            },
            {
              "name": "(Web) Manage Activity Log",
              "system_name": "ManageActivityLog",
              "category": "Configuration",
              "id": 3
            },
            {
              "name": "(Web) Manage Devices",
              "system_name": "ManageDevices",
              "category": "Device Management",
              "id": 4
            },
            {
              "name": "(Web) Manage Report",
              "system_name": "ManageReports",
              "category": "Device Management",
              "id": 5
            },
            {
              "name": "(Web) Manage Stock Order Limits",
              "system_name": "ManageOrderLimit",
              "category": "Configuration",
              "id": 6
            },
            {
              "name": "(Web) Manage Push Notification",
              "system_name": "ManagePushNotification",
              "category": "Push Notification",
              "id": 7
            },
            {
              "name": "(Web) Manage Outlet Management",
              "system_name": "ManageOutletManagement",
              "category": "Outlet Management",
              "id": 8
            },
            {
              "name": "(Web) Manage Outlet Grouping",
              "system_name": "ManageStoreGroup",
              "category": "Outlet Management",
              "id": 9
            },
            {
              "name": "(Web) Manage Assigning User to Outlet",
              "system_name": "ManageUserStore",
              "category": "Outlet Management",
              "id": 10
            },
            {
              "name": "(Web) Manage ACL",
              "system_name": "ManageAcl",
              "category": "Configuration",
              "id": 11
            },
            {
              "name": "(Web) Manage Plugins",
              "system_name": "ManagePlugins",
              "category": "Configuration",
              "id": 12
            },
            {
              "name": "(Web) Manage Maintenance",
              "system_name": "ManageMaintenance",
              "category": "Maintenance",
              "id": 13
            },
            {
              "name": "(Web) Manage Settings",
              "system_name": "ManageSettings",
              "category": "Configuration",
              "id": 14
            },
            {
              "name": "(HHT) Manage Transporter Receive",
              "system_name": "TRNS_RCV",
              "category": "Transporter Receive",
              "id": 15
            },
            {
              "name": "(HHT) Manage Stock Receive",
              "system_name": "RCV",
              "category": "Stock Receive",
              "id": 16
            },
            {
              "name": "(HHT) Manage Stock Receive Enquiry",
              "system_name": "RCV_ENQ",
              "category": "Stock Receive",
              "id": 17
            },
            {
              "name": "(HHT) Manage Freshness",
              "system_name": "FRESH",
              "category": "Freshness",
              "id": 18
            },
            {
              "name": "(HHT) Manage Stock Order",
              "system_name": "ORD",
              "category": "Stock ORder",
              "id": 19
            },
            {
              "name": "(HHT) Manage Stock Take Result",
              "system_name": "ST_RES",
              "category": "Stock Take",
              "id": 20
            },
            {
              "name": "(HHT) Manage Stock Take",
              "system_name": "ST",
              "category": "Stock Take",
              "id": 21
            },
            {
              "name": "(HHT) Manage Shift Stock Take",
              "system_name": "SHIFT_ST",
              "category": "Stock Take",
              "id": 22
            },
            {
              "name": "(HHT) Manage Zeroise",
              "system_name": "ZERO",
              "category": "Stock Take",
              "id": 23
            },
            {
              "name": "(HHT) Manage Stock Return",
              "system_name": "RTN",
              "category": "Stock Return",
              "id": 24
            },
            {
              "name": "(HHT) Manage Stock Return Enquiry",
              "system_name": "RTN_ENQ",
              "category": "Stock Return",
              "id": 25
            },
            {
              "name": "(HHT) Manage Transporter Collection",
              "system_name": "TRNS_COL",
              "category": "Transporter Collection",
              "id": 26
            },
            {
              "name": "(HHT) Manage Location Enquiry",
              "system_name": "LOC_ENQ",
              "category": "Location Control",
              "id": 27
            },
            {
              "name": "(HHT) Manage Location Registration",
              "system_name": "LOC_REG",
              "category": "Location Control",
              "id": 28
            },
            {
              "name": "(HHT) Manage Transfer In",
              "system_name": "T_IN",
              "category": "Interbranch",
              "id": 29
            },
            {
              "name": "(HHT) Manage Transfer Out",
              "system_name": "T_OUT",
              "category": "Interbranch",
              "id": 30
            },
            {
              "name": "(HHT) Manage Price Tag Print",
              "system_name": "PRN_PRC_TAG",
              "category": "Label Request",
              "id": 31
            },
            {
              "name": "(HHT) Manage Location Barcode Print",
              "system_name": "PRN_LOC_BAR",
              "category": "Label Request",
              "id": 32
            },
            {
              "name": "(HHT) Manage Planogram",
              "system_name": "PGRAM",
              "category": "Planogram",
              "id": 33
            },
            {
              "name": "(HHT) Manage Notification Summary",
              "system_name": "NOT_SUM",
              "category": "Notification Summary",
              "id": 34
            },
            {
              "name": "(HHT) Manage Transaction Summary",
              "system_name": "TXN_SUM",
              "category": "Transaction Summary",
              "id": 35
            },
            {
              "name": "(Web) Manage System Log",
              "system_name": "ManageSystemLog",
              "category": "Maintenance",
              "id": 36
            }
          ],
          "id": 1
        },
        {
          "name": "Registered",
          "active": true,
          "is_system_role": true,
          "system_name": "Registered",
          "permissions": [
            {
              "name": "(Web) Access panel",
              "system_name": "AccessPanel",
              "category": "Standard",
              "id": 1
            },
            {
              "name": "(Web) Manage Devices",
              "system_name": "ManageDevices",
              "category": "Device Management",
              "id": 4
            },
            {
              "name": "(Web) Manage Report",
              "system_name": "ManageReports",
              "category": "Device Management",
              "id": 5
            },
            {
              "name": "(Web) Manage Stock Order Limits",
              "system_name": "ManageOrderLimit",
              "category": "Configuration",
              "id": 6
            },
            {
              "name": "(Web) Manage Push Notification",
              "system_name": "ManagePushNotification",
              "category": "Push Notification",
              "id": 7
            },
            {
              "name": "(Web) Manage Outlet Management",
              "system_name": "ManageOutletManagement",
              "category": "Outlet Management",
              "id": 8
            }
          ],
          "id": 3
        }
      ],
      "Stores": [],
      "Id": 1
    }
  ],
  "WebHookId": "79bc3fe2439e45749c9cf14764d508a9"
}
```
