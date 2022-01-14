using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class Collection
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public ExponentItem ExponentItem { get; set; }
        public int ExponentItemId { get; set; }
    }
}
