
namespace SurveyBasket.Infrastructure.EntitiesConfigurations
{
    public class VoteAnswerConfigurations : IEntityTypeConfiguration<VoteAnswer>
    {
        public void Configure(EntityTypeBuilder<VoteAnswer> builder)
        {
            builder.HasIndex(vs => new { vs.VoteId, vs.QuestionId }).IsUnique();
        }
    }
}
