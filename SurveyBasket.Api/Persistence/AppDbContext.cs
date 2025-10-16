using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;

namespace SurveyBasket.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) :
        IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Poll> Polls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
