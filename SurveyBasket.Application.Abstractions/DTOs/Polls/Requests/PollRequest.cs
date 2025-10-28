namespace SurveyBasket.Application.Abstractions.DTOs.Polls.Requests
{
    public record PollRequest(
        string Title,
        string Summary,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
}
