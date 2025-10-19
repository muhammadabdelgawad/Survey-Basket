namespace SurveyBasket.Contracts.Polls.Requests
{
    public record PollRequest(
        string Title,
        string Summary,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
}
