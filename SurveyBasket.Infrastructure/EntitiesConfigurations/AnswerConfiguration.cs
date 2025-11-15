namespace SurveyBasket.Infrastructure.EntitiesConfigurations
{
    public class AnswerConfiguration :IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(a => a.Content)
                   .HasMaxLength(1000);

            builder.HasIndex(a => new { a.QuestionId, a.Content })
                   .IsUnique();
        }
    

    }
}
