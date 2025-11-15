using SurveyBasket.Application.Abstractions.DTOs.Polls.Responses;

namespace SurveyBasket.Application.Services
{
    public class PollService(AppDbContext context) : IPollService
    {
        private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbContext.Polls.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var poll = await _dbContext.Polls.FindAsync(id, cancellationToken);
            return poll is not null
                ? Result.Success(poll.Adapt<PollResponse>())
                : Result.Failure<PollResponse>(PollErrors.PollNotFound);
        }

        public async Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default)
        {
            var isExistingTitle = await _dbContext.Polls.AnyAsync(x => x.Title == request.Title, cancellationToken: cancellationToken);

            if (isExistingTitle)
                return Result.Failure<PollResponse>(PollErrors.DuplicatedPollTitle);

            var poll = request.Adapt<Poll>();

            await _dbContext.AddAsync(poll, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success(poll.Adapt<PollResponse>());
        }

        public async Task<Result> UpdateAsync(int id, PollRequest request, CancellationToken cancellationToken = default)
        {
            var isExistingTitle = await _dbContext.Polls.AnyAsync(x => x.Title == request.Title && x.Id != id, cancellationToken: cancellationToken);

            if (isExistingTitle)
                return Result.Failure<PollResponse>(PollErrors.DuplicatedPollTitle);

            var currentPoll = await _dbContext.Polls.FindAsync(id, cancellationToken);

            if (currentPoll is null)
                return Result.Failure(PollErrors.PollNotFound);

            currentPoll.Title = request.Title;
            currentPoll.Summary = request.Summary;
            currentPoll.StartsAt = request.StartsAt;
            currentPoll.EndsAt = request.EndsAt;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken)
        {

            var poll = await _dbContext.Polls.FindAsync(id, cancellationToken);

            if (poll is null)
                return Result.Failure(PollErrors.PollNotFound);

            _dbContext.Remove(poll);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result> TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default)
        {
            var poll = await _dbContext.Polls.FindAsync(id, cancellationToken);

            if (poll is null)
                return Result.Failure(PollErrors.PollNotFound);

            poll.IsPublished = !poll.IsPublished;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();

        }
    }
}
