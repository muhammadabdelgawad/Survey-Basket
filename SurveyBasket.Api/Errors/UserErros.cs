namespace SurveyBasket.Errors
{
    public static class UserErros
    {
        public static readonly Error InvalidCredentials = 
            new("User.InvalidCredentials", "Invalid Email or Password");
    }
}
 