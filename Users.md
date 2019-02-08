
# What can you do with Users?

The API lets you do the following with the User resource.

+ [GET /api/users  
Receive a list of all Users](#get-apiusers)

+ [GET /api/users/search   
Search for users matching supplied query](#get-apiuserssearch)

+ [GET /api/users/{id}  
Receive a single User](#get-apiusersid)

+ [POST /api/users  
Create a new User](#post-apiusers)

+ [PUT /api/users/{id}  
Modify an existing User](#put-apiusersid)

+ [DELETE /api/users/{id}  
Remove a User](#delete-apiusersid)

+ [GET /api/users/count  
Receive a count of all Users](#get-apiusersscount)

# User Endpoints

## GET /api/users  
Retrieve all users

|  GET |  /api/users |
|:---|:---|
|  since_id |  Restrict results to after the specified ID |
|  created_at_min |  Show users created after date (format: 2014-04-25T16:15:47-04:00) |
|  created_at_max |  Show users created before date (format: 2014-04-25T16:15:47-04:00) |
|  limit |  Amount of results (default: 50) (maximum: 250) |
|  page |  Page to show (default: 1) |
|  fields |  Comma-separated list of fields to include in the response |

#### GET /api/users  
Get all users

<details><summary>Response</summary>
<p> Coming soon.. </p></details>

#### GET /api/users?created_at_min=2016-09-30T08:56:13.85  
Get all users created after a certain date

<details><summary>Response</summary>
<p> Coming soon.. </p></details>


## GET /api/users/search  
Search for users matching supplied query

|  GET |  /api/users/search |
|:---|:---|
|  order |  Field and direction to order results by (default: id DESC) |
|  query |  Text to search users |
|  limit |  Amount of results (default: 50) (maximum: 250) |
|  page |  Page to show (default: 1) |
|  fields |  Comma-separated list of fields to include in the response |

#### GET /api/users/search?query=first_name:john  
Get all users with first name "John"

<details><summary>Response</summary>
<p> Coming soon.. </p></details>


## GET /api/users/{id}  
Retrieve users by specified id

|  GET |  /api/users/{id} |
|:---|:---|
|  fields |  Comma-separated list of fields to include in the response |

#### GET /api/users/1  
Get a single users with id 1

<details><summary>Response</summary>
<p> Coming soon.. </p></details>

#### GET /api/users/1?fields=id,email  
Get a single user with id 1 and only the id and the email in the response

<details><summary>Response</summary>
<p> Coming soon.. </p></details>


## PUT /api/users/{id}  
Update an existing user

#### Update details for a user  
PUT /api/users/666  
```json
{
  "user": {
    "admin_comment": "User is a great guy"
  }
}
```

<details><summary>Response</summary>
<p> Coming soon.. </p></details>

