namespace SurveyBasket.Contracts.Requests
{
    public record CreatePollRequest(
        string Tittle,
        string Summary,
        bool Ispublished,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
}
