namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public class VoteErrors
    {
        public static readonly Error InvalidQuestions =
           new("Vote.InvalidQuestions",  " Invalid questions");


        public static readonly Error DuplicatedVote =
            new("Vote.Duplicated", "this user is already voted before");

    }
}
