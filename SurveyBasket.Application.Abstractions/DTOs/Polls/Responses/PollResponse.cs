namespace SurveyBasket.Application.Abstractions.DTOs.Polls.Responses
{
    public record PollResponse(
        int Id,
        string Title,
        string Summary,
        bool Ispublished,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
   
}
