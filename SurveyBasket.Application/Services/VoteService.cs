namespace SurveyBasket.Application.Services
{
    public class VoteService(AppDbContext dbContext) : IVoteService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default)
        {
            var isVoted = await _dbContext.Votes.AnyAsync(v => v.PollId == pollId && v.UserId == userId, cancellationToken);
            if (isVoted)
                return Result.Failure(VoteErrors.DuplicatedVote);

            var pollExists = await _dbContext.Polls.AnyAsync(p => p.Id == pollId && p.IsPublished && p.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow) && p.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow));

            if (!pollExists)
                return Result.Failure(PollErrors.PollNotFound);

            var availableQuestions = await _dbContext.Questions
                .Where(q=>q.PollId == pollId && q.IsActive)
                .Select(q=>q.Id)
                .ToListAsync(cancellationToken);

            if(!request.Answers.Select(x=>x.QuestionId).SequenceEqual(availableQuestions))
                return Result.Failure(VoteErrors.InvalidQuestions);

            var vote = new Vote
            {
                Id = pollId,
                UserId = userId,
                SubmittedOn = DateTime.UtcNow,
                VoteAnswers = request.Answers.Adapt<IEnumerable<VoteAnswer>>().ToList()
            };

            await _dbContext.Votes.AddAsync(vote, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Result.Success();

        }
    }
}
