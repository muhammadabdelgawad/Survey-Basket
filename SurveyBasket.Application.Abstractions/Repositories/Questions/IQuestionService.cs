
namespace SurveyBasket.Application.Abstractions.Repositories.Questions
{
    public interface IQuestionService
    {
        Task<Result<QuestionResponse>> AddAsync(int pollId ,QuestionRequest request,CancellationToken cancellationToken = default);
        Task<Result<QuestionResponse>> UpdateAsync(QuestionRequest request, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<QuestionResponse>>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Result<QuestionResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
        Task Delete(int id,CancellationToken cancellationToken = default);
    }
}
