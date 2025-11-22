namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public class PollErrors
    {
        public static readonly Error PollNotFound =
           new("Poll.NotFound", "No poll was found with given Id",StatusCodes.Status404NotFound);


        public static readonly Error DuplicatedPollTitle =
            new("Poll.DuplicatedTitle", "Another poll with the same title is already exists", StatusCodes.Status409Conflict);

    }
}
