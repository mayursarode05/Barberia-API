using Barberia.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Infrastructure.Data
{
    public class BarberiaDbContext : IdentityDbContext
    {
        public BarberiaDbContext(DbContextOptions<BarberiaDbContext> options) : base(options)
        {
            
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Lookups> Lookups { get; set; }
    }
}
