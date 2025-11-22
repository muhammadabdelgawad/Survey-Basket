namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public class VoteErrors
    {
        //public static readonly Error VoteNotFound =
        //   new("Vote.NotFound", "No vote was found with given Id");


        public static readonly Error DuplicatedVote =
            new("Vote.Duplicated", "this user is already voted before");

    }
}
