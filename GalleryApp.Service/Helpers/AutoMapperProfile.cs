using AutoMapper;
using GalleryApp.Core.Models;
using GalleryApp.Service.ViewModels.Exhbition;
using GalleryApp.Service.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ExhibitionVM, Exhibition>()
                    .ForMember(exhibition => exhibition.Organizer, opts => opts.MapFrom(exhibition => exhibition.Organizer));

            CreateMap<Exhibition, ExhibitionVM>().ReverseMap();

            CreateMap<UserVM, User>()
                .ForMember(user => user.Username, opts => opts.MapFrom(user => user.Username))
                .ForMember(user => user.LastName, opts => opts.MapFrom(user => user.LastName))
                .ForMember(user => user.FirstName, opts => opts.MapFrom(user => user.FirstName));

            CreateMap<UserVM, User>().ReverseMap();
        }
    }
}
