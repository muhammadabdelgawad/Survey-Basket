namespace SurveyBasket.Application.Abstractions.DTOs.Votes.Request
{
    public record VoteAnswerRequest
    (
        int QuestionId,
        int AnswerId
    );
   
}
