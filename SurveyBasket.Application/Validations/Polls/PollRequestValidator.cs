
namespace SurveyBasket.Application.Validations.Polls
{
    public class PollRequestValidator : AbstractValidator<PollRequest>
    {
        public PollRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(3, 100);

            RuleFor(x => x.Summary)
                .NotEmpty()
                .Length(5, 1500);

            RuleFor(x => x.StartsAt)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));

            RuleFor(x => x.EndsAt)
                .NotEmpty();

            RuleFor(x => x)
                .Must(HasValidDate)
                .WithName(nameof(PollRequest.EndsAt))
                .WithMessage("{PropertyName} Must be grater than or equals start date");

        }
        private bool HasValidDate(PollRequest pollRequest)
        { 
            return pollRequest.EndsAt >= pollRequest.StartsAt; 
        }
    } 
}
