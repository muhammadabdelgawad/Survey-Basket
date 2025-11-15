namespace SurveyBasket.Application.Validations.Questions
{
    public class QuestionRequestValidator : AbstractValidator<QuestionRequest>
    {
        public QuestionRequestValidator()
        {
            RuleFor(x => x.Content)
            .NotEmpty()
            .Length(3, 1000);

            RuleFor(x => x.QuestionAnswers)
                .NotNull();

            RuleFor(x => x.QuestionAnswers)
                .Must(x => x.Count > 1)
                .WithMessage("Question should has at least 2 answers")
                .When(x => x.QuestionAnswers != null);

            RuleFor(x => x.QuestionAnswers)
                .Must(x => x.Distinct().Count() == x.Count)
                .WithMessage("You cannot add duplicated answers for the same question")
                .When(x => x.QuestionAnswers != null);

        }
    }
}
