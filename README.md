# azure-directory-protected-api
Azure AD Authentication to protect the ASP.NET Core Web API so that only authenticated users can access it.

### Prerequisites
- .NET CORE
- Visual Studio
- Microsoft Azure Account


## Setup the application registrations in Azure

Register two Azure AD applications: One registration will be used for the Web API and a second registration is used for the UI application.

### Setup the Web API application registration

- In the Azure Active directory, register a new application for web API.
- Click the Expose an API, and add a new scope using Add a scope.
- Now add the **access_as_user** scope. This scope can be used as “api://–clientId–/access_as_user”

### Setup the UI application registration
Postman can be used as client application and this will the access the API.

- Create a new registration for the UI, set the redirect URL to "https://www.postman.com/oauth2/callback".
- Add a permission> My APIs and add above create API application.
- In Certificates & secrets, create a new secret, and save this for later usage.

### Use this repository
```sh
$ git clone https://github.com/deepaksnegi/azure-directory-protected-api
$ cd azure-directory-protected-api

```

Modify the AzureAd configuration in the app.settings.json.
```sh
{
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "TenantId": "azure ad tenant id",
    "ClientId": "api app client id"
  },
}
```
### Postman configuration as a client
Postman will be used as client application to get access token from Azure Ad using OAuth 2.0.
- Open postman for GET request and URL as "https://localhost:44383/users"
- Select Authorization and type OAuth 2.0.
- Setup configure token as follows
- Token Name: Azure AD, Grant type: Authorization code, callback url: https://www.postman.com/oauth2/callback, Client Id: client app id from azure, client secret: client app secret, scope: API scope (api://–clientId–/access_as_user), state: leave empty
- Auth URL: https://login.microsoftonline.com/tenant-id/oauth2/v2.0/authorize and Access token URL: https://login.microsoftonline.com/tenat-id/oauth2/v2.0/token
- Get access token and use the token to access API.

