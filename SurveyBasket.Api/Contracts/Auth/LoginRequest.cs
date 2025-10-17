namespace SurveyBasket.Contracts.Auth
{
    public record LoginRequest(
    
        string Email,
        string Password
    );
}
