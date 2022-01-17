using GalleryApp.Core.Models;
using GalleryApp.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.Helpers
{
    public static class MyAuthTokenExtension
    {
        public static Account GetUserOfAuthToken(this HttpContext httpContext)
        {
            string _token = httpContext.GetAuthToken();

            GalleryContext GalleryContext = httpContext.RequestServices.GetService<GalleryContext>();

            Account account = GalleryContext.AuthenticationTokens.Where(token => _token != null && token.Value == _token).Select(account => account.Account).SingleOrDefault();

            return account;
        }

        public static string GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["authentication-token"];

            return token;
        }
    }
}
