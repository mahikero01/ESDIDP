# ESDIDP
IDP -> Identification Provider
JWT -> JSON Web Token

Confidential clients -> Capable of confidentiality of their credentitlas (e.g. server-side web apps)
Public cients -> Incapable of maintaining the confidentiality of their credentials (javascript apps, mobile apps)
TLS -> Transport Layer Security 
SSL -> Secured Sockets Layer

RBAC -> Role-base Access Control
ABAC -> Attribute-based Access Control (CBAC -> Claims-based Access Control) (PBAC -> Policy-based Access Control)



Identity Server -> OpenID Connect and OAuth2 framework for ASP.NET Core by Dominick Baier and Brock Allen


Token Lifetimes and Expiration

Identity token
1) Very short lifetime (default: 5 minutes)
2) Used right after delivery
3) applications often implement their own expiration policies


Access token
1) Longer lifetime (default: 1 hour)
2) Must be renewed to regain access to resources
3) The IDP controls the expiration policy


Dependencies for ESDIDP Project(https://localhost:44379):
1) IdentityServer4
2) Microsoft.Extensions.Logging.Debug
3) Microsoft.aspnetcore.mvc
3) Microsoft.aspnetcore.StaticFiles
4) obtain zip files https://github.com/IdentityServer/IdentityServer4.Quickstart.UI
5) Microsoft.EntityFrameworkCore.SqlServer
6) Microsoft.EntityFrameworkCore.Tools
7) Microsoft.Extensions.Configuration.Json  (set properties of appsetting.json "Copy to Output Directory -> Copy always")
8) Microsoft.AspNetCore.Authentication.Facebook

Dependencies of ImageClient(https://localhost:44355):
1) Microsoft.aspnetcore.Authentication.Cookies
2) Microsoft.aspnetcore.Authentication.OpenIdConnect
3) IdentityModel
4) Microsoft.AspNetCore.Authorization

Dependencies of ImageAPI (https://localhost:44322):  
1) IdentityServer4.AccessTokenValidation



EF Core Commands:
1) add-migration InitialESDUserDBMigration  -> adds a migration folder and snapshot


