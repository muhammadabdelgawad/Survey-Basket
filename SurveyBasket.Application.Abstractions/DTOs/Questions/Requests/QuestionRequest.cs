namespace SurveyBasket.Application.Abstractions.DTOs.Questions.Requests
{
    public record QuestionRequest(
     string Content,
     List<string> Answers
    );
}
