namespace SurveyBasket.Contracts.Responses
{
    public record PollResponse(
        int Id,
        string Tittle,
        string Summary,
        bool Ispublished,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
   
}
