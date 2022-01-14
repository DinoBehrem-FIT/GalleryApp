using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class ExhibitionSubscriptions
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public Exhibition Exhibition { get; set; }
        public int ExhibitionId { get; set; }

        public bool Reminder { get; set; }
    }
}
