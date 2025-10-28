using SurveyBasket.Application.Abstractions.DTOs.Polls.Requests;
using SurveyBasket.Application.Abstractions.DTOs.Polls.Responses;

namespace SurveyBasket.Application.Abstractions.Repositories.Polls
{
    public interface IPollService
    {
        Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken=default);

        Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken=default);
        Task <Poll> AddAsync(Poll poll , CancellationToken cancellationToken = default);
        Task<Result> UpdateAsync(int id, PollRequest poll, CancellationToken cancellationToken=default);
        Task<bool> DeleteAsync(int id,CancellationToken cancellationToken= default);
        Task<bool> TogglePublishStatusAsync(int id,CancellationToken cancellationToken= default);


    }
}
