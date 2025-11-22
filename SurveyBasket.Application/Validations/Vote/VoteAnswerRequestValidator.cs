namespace SurveyBasket.Application.Validations.Vote
{
    public class VoteAnswerRequestValidator :AbstractValidator<VoteAnswerRequest>
    {
        public VoteAnswerRequestValidator()
        {
            RuleFor(x => x.QuestionId)
                .GreaterThan(0)
                .WithMessage("Question Id must be greater than 0");

            RuleFor(x => x.AnswerId)
                .GreaterThan(0)
                .WithMessage("Answer Id must be greater than 0");
        }
    }
}
