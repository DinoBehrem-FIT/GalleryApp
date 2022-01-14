using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryApp.Core.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }
        public int AccountId { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
        
    }
}
