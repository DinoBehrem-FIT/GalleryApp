using GalleryApp.Core.Models;
using GalleryApp.Repository.Repostiory;
using GalleryApp.Service.Interfaces;
using GalleryApp.Service.ViewModels.Login;
using GalleryApp.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.Services
{
    // service.scoped to do
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<Account> AccountRepository;

        public AuthenticationService(IRepository<Account> accountRepository)
        {
            this.AccountRepository = accountRepository;
        }
        public Account GetAccount(LoginVM login)
        {
            return AccountRepository.GetAll().Where(account => account.Username == login.Username && account.Password == login.Password).SingleOrDefault();
        }
    }
}
