using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthServer.Config
{
    public static class IDS_Config
    {
        public static List<TestUser> testUsers
        {
            get
            {
                return new List<TestUser>()
                {
                    new TestUser() {
                        SubjectId = "1234",
                        Username = "admin",
                        Password = "admin",
                        Claims = {
                            new Claim(JwtClaimTypes.Name,"Armin Smajlagic"),
                            new Claim(JwtClaimTypes.Role,"admin"),
                        }
                    }
                };
            }

            set
            {

            }
        }

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };
        //,
        //new IdentityResource
        //{
        //  Name = "role",
        //  UserClaims = new List<string> {"role"}
        //}
    public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope(name:"cinestar_api.read",displayName:"Read data from server",userClaims:new[]{"standard_user" }),
            new ApiScope(name:"cinestar_api.write",displayName:"Write data to server",userClaims:new[]{"admin_user" }),
        };
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
            new ApiResource("cinestar_api")
            {
            Scopes = { "cinestar_api.read", "cinestar_api.write"},
            ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
            UserClaims = new List<string> {"role"}
            }
        };

        public static IEnumerable<Client> Clients => new[]
        {
            // web client credentials flow client
            new Client
            {
              ClientId = "web.client",

              ClientName = "Client Credentials Client",

              AllowedGrantTypes = GrantTypes.ClientCredentials,

              ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

              AllowedScopes = { "cinestar_api.read", "cinestar_api.write","openid","profile" },

              //RedirectUris = { "https://localhost:44396/signin-oidc" }
            },

            // interactive client using code flow + pkce
            new Client
            {
              ClientId = "interactive",

              ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

              RequireClientSecret = false,

              AllowedGrantTypes = GrantTypes.Code,

              RedirectUris = {"https://localhost:44396/Auth/Login"},
              //FrontChannelLogoutUri = "https://localhost:4200",
              PostLogoutRedirectUris = {"http://localhost:4200"},
              AllowedCorsOrigins = { "http://localhost:4200" },


              AllowOfflineAccess = true,
              AllowAccessTokensViaBrowser = true,

              AllowedScopes = {"cinestar_api.read","openid"},

              RequireConsent = false,
                  RequirePkce = true,

            },
        };
    }
}
