namespace SurveyBasket.Domain.Entities
{
    public sealed class Answer : AuditableEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;

        public int QuestionId { get; set; }
        public bool IsAcvite { get; set; } = true;

        public Question Question { get; set; } = default!;

    }
}
