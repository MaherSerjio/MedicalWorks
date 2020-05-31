using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Claim> Claims { get; set; }

        public DbSet<Beneficiary> Beneficiaries { get; set; }

        public DbSet<Policy> Policies { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Relationship> Relationships { get; set; }
    }
}
