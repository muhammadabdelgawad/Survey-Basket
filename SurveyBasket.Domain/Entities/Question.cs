
namespace SurveyBasket.Domain.Entities
{
    public sealed class Question : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;

        public int PollId { get; set; }
        public bool IsAcvite { get; set; } = true;

        public Poll poll { get; set; } = default!;

        public ICollection<Answer> Answers { get; set; } = [];

    }
}
