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
using GalleryApp.Service.ViewModels.User;

namespace GalleryApp.Service.Services
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IRepository<Exhibition> ExhibitionRepository;
        private readonly IUserService UserService;
        private readonly IMapper Mapper;

        public ExhibitionService(IRepository<Exhibition> exhibitionRepository, IUserService userService, IMapper mapper)
        {
            ExhibitionRepository = exhibitionRepository;
            this.UserService = userService;
            Mapper = mapper;
        }
        public void Add(Account organizer, ExhibitionCreationVM obj)
        {
            Exhibition exhibition = new Exhibition() 
            {
                Title = obj.Title,
                Description = obj.Description,
                StartingDate = obj.StartingDate,
                OrganizerId = organizer.Id
            };

            ExhibitionRepository.Add(exhibition);
        }

        public void Delete(ExhibitionVM obj)
        {
            throw new NotImplementedException();
        }

        public ExhibitionVM GetExhbition(string id)
        {
            Exhibition exhibition = ExhibitionRepository.GetAll().Where(exhibition => exhibition.Title == id).FirstOrDefault();

            if (exhibition == null)
            {
                return null;
            }
            exhibition.Organizer = UserService.GetById(exhibition.OrganizerId);

            return Mapper.Map<ExhibitionVM>(exhibition);
        }

        public IEnumerable<ExhibitionVM> GetExhbitions()
        {
            return ExhibitionRepository.GetAll().Select(exhibition => new ExhibitionVM()
            {
                Title = exhibition.Title,
                Description = exhibition.Description,
                StartingDate = exhibition.StartingDate,
                Organizer = Mapper.Map<UserVM>(UserService.GetById(exhibition.OrganizerId))
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

        public IEnumerable<ExhibitionVM> GetExhibitionsByFilters(ExhibitionFiltersVM exhibitionFilters)
        {
            IEnumerable<ExhibitionVM> exhibitionFiltersList = ExhibitionRepository.GetAll().Where(exhibition => (Mapper.Map<UserVM>(UserService.GetById(exhibition.OrganizerId)).Username == exhibitionFilters?.CreatatorName || string.IsNullOrEmpty(exhibitionFilters.CreatatorName)) && exhibition.StartingDate >= exhibitionFilters.DateFrom && exhibition.StartingDate <= exhibitionFilters.DateTo).Select(exhibition => Mapper.Map<ExhibitionVM>(exhibition)).ToList();

            return exhibitionFiltersList;
        }

        public void Update(ExhibitionVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
