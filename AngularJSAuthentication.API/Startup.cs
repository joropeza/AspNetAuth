using AngularJSAuthentication.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Twitter;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin.Security.Providers.LinkedIn;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(AngularJSAuthentication.API.Startup))]

namespace AngularJSAuthentication.API
{
    public class Startup
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static GoogleOAuth2AuthenticationOptions googleAuthOptions { get; private set; }
        public static FacebookAuthenticationOptions facebookAuthOptions { get; private set; }
        public static TwitterAuthenticationOptions twitterAuthOptions { get; private set; }
        public static LinkedInAuthenticationOptions linkedinAuthOptions { get; private set; }


        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, AngularJSAuthentication.API.Migrations.Configuration>());

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
            
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);

            //Configure Google External Login
            googleAuthOptions = new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "xxxxxx",
                ClientSecret = "xxxxxx",
                Provider = new GoogleAuthProvider()
            };
            app.UseGoogleAuthentication(googleAuthOptions);

            //Configure Facebook External Login
            facebookAuthOptions = new FacebookAuthenticationOptions()
            {
                AppId = "696434357104240",
                AppSecret = "4f01e552dbbec0d79a5fb7419c8c8026",
                Provider = new FacebookAuthProvider()
            };
            app.UseFacebookAuthentication(facebookAuthOptions);

            //Configure Twitter External Login
           twitterAuthOptions = new TwitterAuthenticationOptions()
            {
                ConsumerKey = "J22ZkRF4BkRQ6P1mSPDFAp7D9",
                ConsumerSecret = "ofgFfLvhfSpDu9IjFToURHN2jVAhshF8I2Wy5WKhZtcH3gc692",
                Provider = new TwitterAuthProvider()
            };
           app.UseTwitterAuthentication(twitterAuthOptions);

           //Configure LinkedIn External Login
           linkedinAuthOptions = new LinkedInAuthenticationOptions()
           {

               ClientId = "753c7mtahb7ujg",
               ClientSecret = "jSbX6K8lAUowRU3H",
               Provider = new LinkedInAuthProvider()
           };
           app.UseLinkedInAuthentication(linkedinAuthOptions);

           

        }
    }

}