
namespace SurveyBasket.Infrastructure.EntitiesConfigurations
{
    public class VoteConfigurations : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasIndex(v => new { v.PollId, v.UserId }).IsUnique();
        }
    }
}
