
namespace SurveyBasket.Contracts.Validations
{
    public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatePollRequestValidator()
        {
            RuleFor(x => x.Tittle)
                .NotEmpty()
                .Length(5, 100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .Length(5, 1000);
        }
    }
}
