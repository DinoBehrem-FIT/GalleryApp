using GalleryApp.Core.Models;
using GalleryApp.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.ViewModels.Login
{
    public class AuthTokenVM
    {
        public string Value { get; set; }
        public DateTime DateCreated { get; set; }
        public string IPAddress { get; set; }
        public GalleryApp.Core.Models.User Account { get; set; }
    }
}
