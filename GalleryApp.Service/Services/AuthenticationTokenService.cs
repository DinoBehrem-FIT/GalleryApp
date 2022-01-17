using GalleryApp.Core.Models;
using GalleryApp.Repository.Repostiory;
using GalleryApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.Services
{
    public class AuthenticationTokenService : IAuthenticationTokenService
    {
        private readonly IRepository<AuthenticationToken> TokenRepository;

        public AuthenticationTokenService(IRepository<AuthenticationToken> tokenRepository)
        {
            this.TokenRepository = tokenRepository;
        }
        public void AddToken(AuthenticationToken token)
        {
            TokenRepository.Add(token);
        }
    }
}
