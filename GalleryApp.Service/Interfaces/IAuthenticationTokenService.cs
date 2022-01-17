using GalleryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.Interfaces
{
    public interface IAuthenticationTokenService
    {
        public void AddToken(AuthenticationToken token);
    }
}
