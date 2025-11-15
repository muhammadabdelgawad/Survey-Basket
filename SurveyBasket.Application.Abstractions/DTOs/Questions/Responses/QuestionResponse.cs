
namespace SurveyBasket.Application.Abstractions.DTOs.Questions.Responses
{
    public record QuestionResponse(
        int Id,
        string Content,
        IEnumerable<AnswerResponse> Answers


    );
}
