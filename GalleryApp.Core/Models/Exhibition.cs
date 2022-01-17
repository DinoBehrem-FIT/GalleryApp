using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class Exhibition
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        //public DateTime ExpiringTime { get; set; }
        //public ICollection<ExponentItem> Images { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public Account Organizer { get; set; }
        public int OrganizerId { get; set; }

    }
}
