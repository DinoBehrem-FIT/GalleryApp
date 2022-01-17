using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class AuthenticationToken
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime DateCreated { get; set; }
        public string IPAddress { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
