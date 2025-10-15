namespace SurveyBasket.Contracts.Responses
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
