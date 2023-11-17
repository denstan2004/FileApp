using Microsoft.EntityFrameworkCore;
using TestAppFile.Enteties;

namespace TestAppFile.DAO
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }
        public DbSet<FileEntity> files { get; set; }
        public DbSet<FileLinks> links { get; set; }
    }
}
