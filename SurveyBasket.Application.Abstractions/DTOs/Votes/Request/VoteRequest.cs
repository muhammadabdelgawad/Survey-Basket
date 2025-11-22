namespace SurveyBasket.Application.Abstractions.DTOs.Votes.Request
{
    public record VoteRequest
    (
       IEnumerable<VoteAnswerRequest> Answers
    );
}
