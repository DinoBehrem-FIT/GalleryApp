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

        [HttpPost]
        public ActionResult CreateExhibition([FromBody]ExhibitionVM data)
        {
            ExhibitionService.Add(data);

            return Ok(data);
        }
    }
}
