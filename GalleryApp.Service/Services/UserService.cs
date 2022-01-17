using AutoMapper;
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
    public class UserService : IUserService
    {
        private readonly IRepository<User> UserRepository;
        private readonly IMapper Mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            this.UserRepository = userRepository;
            this.Mapper = mapper;
        }

        public UserVM Add(RegistrationVM data)
        {
            UserRepository.Add(new User()
            {
                FirstName = data.Firstname,
                LastName = data.Lastname,
                Username = data.Username,
                Password = data.Password
            });

            return new UserVM() {
                FirstName = data.Firstname,
                LastName = data.Lastname,
                Username = data.Username
            };
        }

        public Account GetById(int organizerId)
        {
            return UserRepository.GetAll().Where(user => user.Id == organizerId).SingleOrDefault();
        }

        public Account GetByLogin(LoginVM login)
        {
            return UserRepository.GetAll().Where(user => user.Username == login.Username && user.Password == login.Password).FirstOrDefault();
        }

        public List<UserVM> GetUsers()
        {
            return UserRepository.GetAll().Select(user => new UserVM()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username
            }).ToList();
        }
    }
}
