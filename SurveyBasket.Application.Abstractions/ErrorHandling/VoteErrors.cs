namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public class VoteErrors
    {
        public static readonly Error InvalidQuestions =
           new("Vote.InvalidQuestions",  " Invalid questions", StatusCodes.Status400BadRequest);


        public static readonly Error DuplicatedVote =
            new("Vote.Duplicated", "this user is already voted before", StatusCodes.Status409Conflict);

    }
}
