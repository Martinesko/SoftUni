using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Library.Data.Model
{
    public class IdentityUserBook
    {
        [Required]
        public string CollectorId { get; set; }

        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; }


        [Required]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}

//CollectorId – a string, Primary Key, foreign key (required)
//    • Collector – IdentityUser
//    • BookId – an integer, Primary Key, foreign key (required)
//    • Book – Book