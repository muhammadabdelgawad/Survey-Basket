
namespace SurveyBasket.Infrastructure.EntitiesConfigurations
{
    public class QuestionConfiguration :IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.Property(q => q.Content).HasMaxLength(1000);

            builder.HasIndex(q => new { q.PollId, q.Content }).IsUnique();
        }
    
    }
}
