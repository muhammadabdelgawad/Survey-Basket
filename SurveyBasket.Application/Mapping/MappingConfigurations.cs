namespace SurveyBasket.Application.Mapping
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<QuestionRequest, Question>()
                .Map(dest => dest.Answers, src => src.QuestionAnswers.Select(answer => new Answer { Content = answer }));
        }
    }
}
    