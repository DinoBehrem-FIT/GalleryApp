using GalleryApp.Service.ViewModels.Exhbition;
using System;
using System.Collections.Generic;

namespace GalleryApp.Service.Interfaces
{
    public interface IExhibitionService
    {
        void Add(ExhibitionVM obj);
        void Update(ExhibitionVM obj);
        void Delete(ExhibitionVM obj);
        IEnumerable<ExhibitionVM> GetExhbitions();
        IEnumerable<ExhibitionVM> GetExhibitionByTitle(string title);
        IEnumerable<ExhibitionVM> GetExhibitionByDate(DateTime dateTime);
    }
}
