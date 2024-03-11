# Asset Management APIs

This document describes the APIs provided by the `AssetManagement` project.

# Table of Contents

- [Asset Management APIs](#asset-management-apis)
  - [Account APIs](#account-apis)
    - [POST /api/account/login](#post-apiaccountlogin)
    - [POST /api/account/register](#post-apiaccountregister)
    - [GET /api/account/refresh-token](#get-apiaccountrefresh-token)
    - [GET /api/account/logout](#get-apiaccountlogout)
    - [POST /api/account/change-password (TO BE COMPLATE)](#post-apiaccountchange-password-to-be-complate)
    - [PATCH /api/account/active-user (TO BE COMPLATE)](#patch-apiaccountactive-user-to-be-complate)
    - [POST /api/account/inactive-user (TO BE COMPLATE)](#post-apiaccountinactive-user-to-be-complate)
    - [GET /api/account/user-role (TO BE COMPLATE)](#get-apiaccountuser-role-to-be-complate)
  - [Asset APIs (TO BE COMPLATE)](#asset-apis-to-be-complate)
    - [GET /api/assets](#get-apiassets)
    - [GET /api/assets/{id}](#get-apiassetsid)
    - [POST /api/assets/create-assets](#post-apiassetscreate-assets)
    - [PUT /api/assets/{id}](#put-apiassetsid)
    - [DELETE /api/assets/{id}](#delete-apiassetsid)
    - [PATCH /api/assets/{id}](#patch-apiassetsid)
    - [PATCH /api/assets/batch/{ids}](#patch-apiassetsbatchids)
## Account APIs

### POST /api/account/login

Authenticates a user.

Request body should be an `AccountLoginDto` object.

```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

Responses:

- 200: Login successful. The access and refresh tokens are returned in the `Authorization` and `refreshToken` headers, respectively.
- 401: Unauthorized. Login failed.

### POST /api/account/register

Registers a new user.

Request body should be an `AccountCreateDto` object.

```json
{
  "email": "user@example.com",
  "password": "password123",
  "confirmPassword": "password123"
}
```

Responses:

- 200: Registration successful. The response body contains the account details.
- 409: Conflict. Registration failed.

### GET /api/account/refresh-token

Refreshes the access token.

The `Authorization` and `refreshToken` headers should contain the current access and refresh tokens, respectively.

Responses:

- 200: Token refreshed. The new access and refresh tokens are returned in the `Authorization` and `refreshToken` headers, respectively.
- 401: Unauthorized. Token refresh failed.
- 204: No Content. Token not refreshed.

### GET /api/account/logout

Logs out a user.

The `Authorization` header should contain the current access token.

Responses:

- 200: Logout successful.
- 401: Unauthorized. Logout failed.

### POST /api/account/change-password (TO BE COMPLATE)

Changes a user's password.

Request body should be an `AccountChangePassword` object.

Responses:

- 200: Password changed successfully.
- 401: Unauthorized. Password change failed.

### PATCH /api/account/active-user (TO BE COMPLATE)

Activates a user. Only available to admin users.

Request body should be an array of email addresses.

Responses:

- 200: User(s) activated successfully.
- 401: Unauthorized. User activation failed.

### POST /api/account/inactive-user (TO BE COMPLATE)

Deactivates a user. Only available to admin users.

Request body should be an array of email addresses.

Responses:

- 200: User(s) deactivated successfully.
- 401: Unauthorized. User deactivation failed.

### GET /api/account/user-role (TO BE COMPLATE)

Gets a user's role.

The `Authorization` header should contain the current access token.

Responses:

- 200: User role retrieved successfully.
- 404: Not Found. User role retrieval failed.


## Asset APIs (TO BE COMPLATE)

### GET /api/assets

Retrieves all assets.

Responses:

- 200: Assets retrieved successfully. The response body contains an array of assets.
- 404: Not Found. No assets found.

### GET /api/assets/{id}

Retrieves an asset by its ID.

Responses:

- 200: Asset retrieved successfully. The response body contains the asset details.
- 404: Not Found. Asset not found.

### POST /api/assets/create-assets

Creates new assets.

Request body should be an array of `AssetCreateDto` object.

Responses:

- 201: Asset created successfully. The response body contains the created asset.
- 400: Bad Request. Asset creation failed.


```json
[
  {
    "name": "Asset Name 1",
    "description": "Asset Description 1",
    "value": 1000
  },
  {
    "name": "Asset Name 2",
    "description": "Asset Description 2",
    "value": 2000
  }
]
```

### PUT /api/assets/{id}

Updates an existing asset.

Request body should be an `AssetUpdateDto` object.

Responses:

- 200: Asset updated successfully. The response body contains the updated asset.
- 400: Bad Request. Asset update failed.
- 404: Not Found. Asset not found.

```json
{
  "name": "Asset Name",
  "description": "Asset Description",
  "value": 1000
}
```

### DELETE /api/assets/{id}

Deletes an existing asset.

Responses:

- 204: No Content. Asset deleted successfully.
- 404: Not Found. Asset not found.

### PATCH /api/assets/{id}

Partially updates an existing asset.

Request body should be a `JsonPatchDocument<AssetUpdateDto>` object.

``` json
[
  { "op": "replace", "path": "/name", "value": "New Asset Name" }
]
```

Responses:

- 204: No Content. Asset updated successfully.
- 400: Bad Request. Asset update failed.
- 404: Not Found. Asset not found.

### PATCH /api/assets/batch/{ids}

Partially updates multiple assets.

The `ids` parameter should be a string of asset IDs separated by '&'.

Request body should be a `JsonPatchDocument<AssetUpdateDto>` object.


``` json
[
  { "op": "replace", "path": "/name", "value": "New Asset Name" }
]
``` 
Responses:

- 204: No Content. Assets updated successfully.
- 400: Bad Request. Assets update failed.
- 404: Not Found. One or more assets not found.