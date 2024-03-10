# Account APIs

This document describes the APIs provided by the `AccountController` in the `AssetManagement` project.

## Endpoints

### POST /api/account/login

Authenticates a user.

Request body should be an `AccountLoginDto` object.

Responses:

- 200: Login successful. The access and refresh tokens are returned in the `Authorization` and `refreshToken` headers, respectively.
- 401: Unauthorized. Login failed.

### POST /api/account/register

Registers a new user.

Request body should be an `AccountCreateDto` object.

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

### POST /api/account/change-password

Changes a user's password.

Request body should be an `AccountChangePassword` object.

Responses:

- 200: Password changed successfully.
- 401: Unauthorized. Password change failed.

### PATCH /api/account/active-user

Activates a user. Only available to admin users.

Request body should be an array of email addresses.

Responses:

- 200: User(s) activated successfully.
- 401: Unauthorized. User activation failed.

### POST /api/account/inactive-user

Deactivates a user. Only available to admin users.

Request body should be an array of email addresses.

Responses:

- 200: User(s) deactivated successfully.
- 401: Unauthorized. User deactivation failed.

### GET /api/account/user-role

Gets a user's role.

The `Authorization` header should contain the current access token.

Responses:

- 200: User role retrieved successfully.
- 404: Not Found. User role retrieval failed.