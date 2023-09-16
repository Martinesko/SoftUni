using System.ComponentModel.DataAnnotations;

namespace Workshop_ASP.NET_and_Databases.Data.Models
{
    using static Workshop_ASP.NET_and_Databases.Data.DataConstants.Post;

    public class Post
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }
        [Required]
        [MaxLength(ContentMaxLenth)]
        public string Content { get; set; }

    }
}
