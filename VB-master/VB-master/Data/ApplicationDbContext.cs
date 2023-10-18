using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VB.Models;

namespace VB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VirtualAccount> VirtualAccount { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Specialist> Specialist { get; set; }
        public DbSet<Admin> Admin { get; set; }

    }
}
