# ESDIDP
IDP -> Identification Provider
JWT -> JSON Web Token

Confidential clients -> Capable of confidentiality of their credentitlas (e.g. server-side web apps)
Public cients -> Incapable of maintaining the confidentiality of their credentials (javascript apps, mobile apps)
TLS -> Transport Layer Security 
SSL -> Secured Sockets Layer


Identity Server -> OpenID Connect and OAuth2 framework for ASP.NET Core by Dominick Baier and Brock Allen


Dependencies for ESDIDP Project:
1) IdentityServer4
2) Microsoft.Extensions.Logging.Debug
3) Microsoft.aspnetcore.mvc
3) Microsoft.aspnetcore.StaticFiles
4) obtain zip files https://github.com/IdentityServer/IdentityServer4.Quickstart.UI

Dependencies of ImageClient:
1) Microsoft.aspnetcore.Authentication.Cookies
2) Microsoft.aspnetcore.Authentication.OpenIdConnect