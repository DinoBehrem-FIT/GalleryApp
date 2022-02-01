using GalleryApp.Core.Models;
using GalleryApp.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GalleryApp.Service.Helpers
{
    public static class MyAuthTokenExtension
    {
        public class LoginInfo
        {
            public AuthenticationToken Token { get; set; }
            [JsonIgnore]
            public Account Account => Token?.Account;
            public LoginInfo(AuthenticationToken authenticationToken)
            {
                Token = authenticationToken;
            }

            public bool isLogged => Account != null;
        }

        public static LoginInfo GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetUserOfAuthToken();

            return new LoginInfo(token);
        }
        public static AuthenticationToken GetUserOfAuthToken(this HttpContext httpContext)
        {
            string _token = httpContext.GetAuthToken();

            GalleryContext GalleryContext = httpContext.RequestServices.GetService<GalleryContext>();

            AuthenticationToken account = GalleryContext.AuthenticationTokens.Include(authToken => authToken.Account).SingleOrDefault(acc => _token != null && acc.Value == _token);

            return account;
        }

        public static string GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["authentication-token"];

            return token;
        }
    }
}
