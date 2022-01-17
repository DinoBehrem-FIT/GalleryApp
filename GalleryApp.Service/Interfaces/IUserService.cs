using GalleryApp.Core.Models;
using GalleryApp.Service.ViewModels.Login;
using GalleryApp.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.Interfaces
{
    public interface IUserService
    {
        public Account GetByLogin(LoginVM login);
        public UserVM Add(RegistrationVM data);
        public List<UserVM> GetUsers();
        public Account GetById(int organizerId);
    }
}
