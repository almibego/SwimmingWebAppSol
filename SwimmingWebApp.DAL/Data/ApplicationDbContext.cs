using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwimmingWebApp.DAL.Entities;

namespace SwimmingWebApp.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Result> Results { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}