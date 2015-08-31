using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using WebMVCDemo.Web.Models;

namespace WebMVCDemo.Web
{
    public partial class Startup
    {
        public const string GoogleClientId = "460174234734-k6i2dl63rfpqd9aetp2n2nakkmc1nibp.apps.googleusercontent.com";
        public const string GoogleClientSecret = "8RSqA-vmFuvBjokGzKGthLxc";

        public const string GooglePlusAccessTokenClaimType = "urn:tokens:gooleplus:accesstoken";


        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);


            // Google Authentication
            GoogleOAuth2AuthenticationOptions authOptions = new GoogleOAuth2AuthenticationOptions();
            authOptions.ClientId = GoogleClientId;
            authOptions.ClientSecret = GoogleClientSecret;

            authOptions.Provider = new GoogleOAuth2AuthenticationProvider
            {
                OnAuthenticated = async ctx =>
                {
                    ctx.Identity.AddClaim(new Claim("urn:tokens:google:accesstoken", ctx.AccessToken));
                    ctx.Identity.AddClaim(new Claim("urn:tokens:gooleplus:accesstoken", ctx.AccessToken));

                }
            };

            authOptions.Scope.Add("https://www.googleapis.com/auth/analytics");
            authOptions.Scope.Add("https://www.googleapis.com/auth/userinfo.email");
            authOptions.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");

            app.UseGoogleAuthentication(authOptions);

            //app.UseGooglePlusAuthentication(
            //    new GooglePlusAuthenticationOptions
            //    {
            //        Caption = "Google+",
            //        ClientId = GooglePlusClientId,
            //        ClientSecret = GooglePlusClientSecret,
            //        Provider = new GooglePlusAuthenticationProvider
            //        {
            //            OnAuthenticated = async context =>
            //            {
            //                context.Identity.AddClaim(new Claim(GooglePlusAccessTokenClaimType, context.AccessToken));
            //            }
            //        }
            //    });
        }

        /// <summary>
        /// The OAuth2.0 scopes required by your project.
        /// </summary>
        public static List<String> SCOPES = new List<string>()
        {
            "https://www.googleapis.com/auth/analytics",
            "https://www.googleapis.com/auth/userinfo.email",
            "https://www.googleapis.com/auth/userinfo.profile",
        };
    }
}