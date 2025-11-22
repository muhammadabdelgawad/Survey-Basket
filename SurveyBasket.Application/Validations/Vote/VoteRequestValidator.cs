using SurveyBasket.Application.Abstractions.DTOs.Votes.Request;

namespace SurveyBasket.Application.Validations.Vote
{
    public class VoteRequestValidator : AbstractValidator<VoteRequest>
    {
        public VoteRequestValidator()
        {
            RuleFor(x => x.Answers)
                .NotNull()
                .WithMessage("Answers cannot be null");
        }
    }
}
