namespace SurveyBasket.Contracts.Auth
{
    public record RefreshTokenRequest(
        string Token,
        string RefreshToken
        );
}
