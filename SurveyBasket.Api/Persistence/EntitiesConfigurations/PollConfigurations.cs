namespace SurveyBasket.Persistence.EntitiesConfigurations
{
    public class PollConfigurations : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasIndex(p => p.Tittle).IsUnique();

            builder.Property(p => p.Tittle).HasMaxLength(200)
                                           .IsRequired();
            builder.Property(p => p.Summary).HasMaxLength(2000);
           





        }
    }
}
