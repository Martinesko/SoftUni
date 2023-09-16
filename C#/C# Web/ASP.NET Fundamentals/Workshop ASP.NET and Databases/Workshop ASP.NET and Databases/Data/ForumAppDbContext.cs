using Microsoft.EntityFrameworkCore;
using Workshop_ASP.NET_and_Databases.Data.Models;

namespace Workshop_ASP.NET_and_Databases.Data
{
    public class ForumAppDbContext : DbContext
    {
        private Post FirstPost { get; set; }
        private Post SecondPost { get; set; }
        private Post ThirdPost { get; set; }
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options ) : base(options)
        {
          
            Database.Migrate();
        }
        public DbSet<Post> Posts { get; init; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPosts();
            modelBuilder.Entity<Post>().HasData(FirstPost,SecondPost,ThirdPost);
            base.OnModelCreating(modelBuilder);
        }

        public void SeedPosts()
        {
            FirstPost = new Post()
            {
                Id = 1,
                Title = "FirstPost",
                Content = "FirstPost hellooooooooo"

            };
            SecondPost = new Post()
            {
                Id = 2,
                Title = "SecondPost",
                Content = "SecondPost hellooooooooo"

            };
            ThirdPost = new Post()
            {
                Id = 3,
                Title = "ThirdPost",
                Content = "ThirdPost hellooooooooo"

            };
        }
    }
}
