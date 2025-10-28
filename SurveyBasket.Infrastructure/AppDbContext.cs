
namespace SurveyBasket.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) :
        IdentityDbContext<ApplicationUser>(options)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public DbSet<Poll> Polls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();
            foreach (var entityEntry in entries) 
            {
                var cureentUserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(x=> x.CreatedById).CurrentValue = cureentUserId;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(x=> x.UpdatedById).CurrentValue = cureentUserId;
                    entityEntry.Property(x=> x.UpdatedOn).CurrentValue = DateTime.UtcNow;
                }

            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
