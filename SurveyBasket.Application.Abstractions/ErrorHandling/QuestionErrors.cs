namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public class QuestionErrors
    {
        public static readonly Error QuestionNotFound =
           new("Question.NotFound", "No Question was found with given Id");


        public static readonly Error DuplicatedQuestionContent =
            new("Question.DuplicatedContent", "Another Question with the same content is already exists");

    }
}
