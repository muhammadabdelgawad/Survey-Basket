namespace SurveyBasket.Application.Abstractions.ErrorHandling
{
    public class QuestionErrors
    {
        public static readonly Error QuestionNotFound =
           new("Question.NotFound", "No Question was found with given Id", StatusCodes.Status404NotFound);


        public static readonly Error DuplicatedQuestionContent =
            new("Question.DuplicatedContent", "Another Question with the same content is already exists", StatusCodes.Status409Conflict);

    }
}
