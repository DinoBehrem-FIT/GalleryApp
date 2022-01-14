using GalleryApp.Core.Models;
using GalleryApp.Service.Interfaces;
using GalleryApp.Service.ViewModels.Exhbition;
using GalleryApp.Repository.Repostiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace GalleryApp.Service.Services
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IRepository<Exhibition> ExhibitionRepository;
        private readonly IMapper Mapper;

        public ExhibitionService(IRepository<Exhibition> exhibitionRepository, IMapper mapper)
        {
            ExhibitionRepository = exhibitionRepository;
            Mapper = mapper;
        }
        public void Add(ExhibitionVM obj)
        {
            Exhibition exhibition = Mapper.Map<Exhibition>(obj);

            ExhibitionRepository.Add(exhibition);
        }

        public void Delete(ExhibitionVM obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExhibitionVM> GetExhbitions()
        {
            return ExhibitionRepository.GetAll().Select(exhibition => new ExhibitionVM()
            {
                Title = exhibition.Title,
                Description = exhibition.Description
            });
        }

        public IEnumerable<ExhibitionVM> GetExhibitionByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExhibitionVM> GetExhibitionByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void Update(ExhibitionVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
