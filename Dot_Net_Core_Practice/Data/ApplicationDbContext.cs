using Dot_Net_Core_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Dot_Net_Core_Practice.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
             
        }
        public DbSet<Books> Books { get; set; }
    }
}
