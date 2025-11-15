namespace SurveyBasket.Application.Mapping
{
    public class MappingConfigurations : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<QuestionRequest, Question>()
                .Ignore(nameof(Question.Answers));
                // .Map(dest => dest.Answers, src => src.Answers.Select(answer => new Answer { Content = answer }));
        }
    }
}
