namespace SurveyBasket.Application.Abstractions.DTOs.Auth
{
    public record RefreshTokenRequest(
        string Token,
        string RefreshToken
        );
}
