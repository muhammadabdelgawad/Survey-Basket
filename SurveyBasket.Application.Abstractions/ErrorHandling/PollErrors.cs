namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public class PollErrors
    {
        public static readonly Error PollNotFound =
           new("Poll.NotFound", "No poll was found with given Id");
    }
}
