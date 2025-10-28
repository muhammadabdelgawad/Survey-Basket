namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public static class UserErros
    {
        public static readonly Error InvalidCredentials = 
            new("User.InvalidCredentials", "Invalid Email or Password");
    }
}
 