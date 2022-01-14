using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class UserSubscriptions
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(SubscriberId))]
        public User Subscriber { get; set; }
        public int SubscriberId { get; set; }
    }
}
