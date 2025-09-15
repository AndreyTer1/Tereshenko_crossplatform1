using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tereshenko_crossplatform1.Models;

namespace Tereshenko_crossplatform1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Tereshenko_Car> Cars { get; set; } = null!;
    }
}
