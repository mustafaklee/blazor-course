using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Week13_new_self_auth.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
