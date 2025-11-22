using SurveyBasket.Application.Abstractions.DTOs.Answers;

namespace SurveyBasket.Application.Mapping
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<QuestionRequest, Question>()
                .Map(dest => dest.Answers, src => src.QuestionAnswers.Select(answer => new Answer 
                { 
                    Content = answer,
                    IsActive = true 
                }));

            config.NewConfig<Question, QuestionResponse>()
                .Map(dest => dest.QuestionAnswers, src => src.Answers.Select(a => new AnswerResponse(a.Id, a.Content)));
        }
    }
}