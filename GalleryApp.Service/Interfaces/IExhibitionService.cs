using GalleryApp.Core.Models;
using GalleryApp.Service.ViewModels.Exhbition;
using System;
using System.Collections.Generic;

namespace GalleryApp.Service.Interfaces
{
    public interface IExhibitionService
    {
        void Add(Account organizer, ExhibitionCreationVM obj);
        void Update(ExhibitionVM obj);
        void Delete(ExhibitionVM obj);
        ExhibitionVM GetExhbition(string id);
        IEnumerable<ExhibitionVM> GetExhbitions();
        IEnumerable<ExhibitionVM> GetExhibitionByTitle(string title);
        IEnumerable<ExhibitionVM> GetExhibitionByDate(DateTime dateTime);
        IEnumerable<ExhibitionVM> GetExhibitionsByFilters(ExhibitionFiltersVM exhibitionFilters);

    }
}
