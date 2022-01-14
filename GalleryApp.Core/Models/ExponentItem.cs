using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class ExponentItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Description { get; set; }
        public string Dimensions { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
        
        [NotMapped]
        public string ImagePath { get { return Image.Substring(Image.IndexOf("\\Images"), Image.Length - Image.IndexOf("\\Images")); } }

        [NotMapped]
        public string Hash { get; set; }


        [ForeignKey(nameof(ExhibitionId))]
        public Exhibition Exhibition { get; set; }
        public int ExhibitionId { get; set; }

        public ExponentItem()
        {
            Hash = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public string Key()
        {
            string title = Name;
            int length = title.IndexOf(" ") == -1 ? title.Length : title.IndexOf(" ");

            return title.Substring(0, length) + Hash;
        }

    }
}
