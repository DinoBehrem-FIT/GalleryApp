using AutoMapper;
using GalleryApp.Core.Models;
using GalleryApp.Service.ViewModels.Exhbition;
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
            //AccommodationImage
            CreateMap<ExhibitionVM, Exhibition>()
                    .ForMember(exhibition => exhibition.Title, opts => opts.MapFrom(exhibition => exhibition.Title))
                    .ForMember(exhibition => exhibition.Description, opts => opts.MapFrom(exhibition => exhibition.Description));

        }
    }
}
