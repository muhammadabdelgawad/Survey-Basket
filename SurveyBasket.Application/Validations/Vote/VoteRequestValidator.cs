namespace SurveyBasket.Application.Validations.Vote
{
    public class VoteRequestValidator : AbstractValidator<VoteRequest>
    {
        public VoteRequestValidator()
        {
            RuleFor(x => x.Answers)
                .NotNull()
                .WithMessage("Answers cannot be null");


            RuleForEach(x => x.Answers)
                .SetInheritanceValidator(v =>
                v.Add(new VoteAnswerRequestValidator())
                );
        }
    }
}
