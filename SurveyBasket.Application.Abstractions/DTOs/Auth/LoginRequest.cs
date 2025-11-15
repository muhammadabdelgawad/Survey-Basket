namespace SurveyBasket.Application.Abstractions.DTOs.Auth
{
    public record LoginRequest(

        string Email,
        string Password
    );
}
