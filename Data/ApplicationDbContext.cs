using Microsoft.EntityFrameworkCore;
using Music_Library_Backend_Project.Songs;

namespace Music_Library_Backend_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet <Song> Songs { get; set;}
        public ApplicationDbContext(DbContextOptions options)  : base(options) 
        {

        }
    }
}
