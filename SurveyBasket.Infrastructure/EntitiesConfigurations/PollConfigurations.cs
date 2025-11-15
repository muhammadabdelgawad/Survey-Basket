
namespace SurveyBasket.Persistence.EntitiesConfigurations
{
    public class PollConfigurations : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasIndex(p => p.Title).IsUnique();

            builder.Property(p => p.Title).HasMaxLength(200)
                                           .IsRequired();
            builder.Property(p => p.Summary).HasMaxLength(2000);
          


        }
    }
}
