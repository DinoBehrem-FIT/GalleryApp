using GalleryApp.Core.Models;
using GalleryApp.Service.Helpers;
using GalleryApp.Service.Interfaces;
using GalleryApp.Service.ViewModels.Login;
using GalleryApp.Service.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;
        private readonly IUserService UserService;
        private readonly IAuthenticationTokenService AuthenticationTokenService;

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService, IAuthenticationTokenService authenticationTokenService)
        {
            AuthenticationService = authenticationService;
            UserService = userService;
            AuthenticationTokenService = authenticationTokenService;
        }

        [HttpPost]
        public ActionResult<UserVM> Register([FromBody]RegistrationVM registration)
        {
            return UserService.Add(registration);
        }

        [HttpGet]
        public ActionResult<List<UserVM>> GetUsers()
        {
            return UserService.GetUsers();
        }

        [HttpPost]
        public ActionResult<AuthTokenVM> Login([FromBody]LoginVM login)
        {
            User account = UserService.GetByLogin(login) as User;

            if (account == null)
            {
                return null; 
            }

            AuthenticationToken token = new AuthenticationToken()
            {
                IPAddress = "1.2.3.4",
                Value = TokenGenerator.Generate(10),
                Account = account,
                DateCreated = DateTime.Now
            };

            AuthenticationTokenService.AddToken(token);

            AuthTokenVM tokenVM = new AuthTokenVM { IPAddress = token.IPAddress, Account = account, Value = token.Value, DateCreated = token.DateCreated };

            return tokenVM;
        }
    }
}
