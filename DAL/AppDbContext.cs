using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Member> Member { get; set; }
    }
}
