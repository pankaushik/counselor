using Counselor.Models;
using Microsoft.EntityFrameworkCore;

namespace Counselor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}