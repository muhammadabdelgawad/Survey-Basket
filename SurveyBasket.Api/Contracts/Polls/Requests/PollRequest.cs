namespace SurveyBasket.Contracts.Polls.Requests
{
    public record PollRequest(
        string Title,
        string Summary,
        bool Ispublished,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
}
