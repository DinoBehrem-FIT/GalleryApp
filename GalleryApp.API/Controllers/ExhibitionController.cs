using GalleryApp.Core.Models;
using GalleryApp.Service.Helpers;
using GalleryApp.Service.Interfaces;
using GalleryApp.Service.ViewModels.Exhbition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExhibitionController : Controller
    {
        private readonly IExhibitionService ExhibitionService;

        public ExhibitionController(IExhibitionService exhibitionService)
        {
            ExhibitionService = exhibitionService;
        }

        [HttpGet]
        public List<ExhibitionVM> Index()
        {

            return ExhibitionService.GetExhbitions().ToList();
        }
        
        [HttpGet]
        public ActionResult<ExhibitionVM> GetByTitle(string title)
        {
            ExhibitionVM exhibition = ExhibitionService.GetExhbition(title);

            if (exhibition == null)
            {
                return BadRequest();
            }

            return Ok(exhibition);
        }

        [HttpPost]
        public ActionResult CreateExhibition([FromBody]ExhibitionCreationVM data)
        {
            Account account = ControllerContext.HttpContext.GetUserOfAuthToken().Account;

            if (account == null)
            {
                return new BadRequestResult();
            }

            ExhibitionService.Add(account, data);

            return Ok(data);
        }

        [HttpGet]
        public ActionResult<List<ExhibitionVM>> GetByFilter(string creatorName, DateTime dateFrom = default, DateTime dateTo = default)
        {

            ExhibitionFiltersVM exhibitionFilters = new ExhibitionFiltersVM()
            {
                CreatatorName = creatorName,
                DateFrom = dateFrom == default ? DateTime.Now : dateFrom,
                DateTo = dateTo == default ? DateTime.MaxValue : dateTo
            };

            List<ExhibitionVM> exhibitions = ExhibitionService.GetExhibitionsByFilters(exhibitionFilters).ToList();

            return exhibitions;
        }
    }
}
