using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }
    }
}
