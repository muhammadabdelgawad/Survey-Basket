


namespace SurveyBasket.Services
{
    public class PollService(AppDbContext context) : IPollService
    {
        private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken =default)
            => await _dbContext.Polls.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Poll?> GetAsync(int id, CancellationToken cancellationToken=default)
            =>await  _dbContext.Polls.FindAsync(id, cancellationToken);

        public async Task<Poll> AddAsync(Poll poll, CancellationToken cancellationToken)
        {
            await _dbContext.Polls.AddAsync(poll, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return poll;
        }

        public async Task<bool> UpdateAsync(int id, Poll poll, CancellationToken cancellationToken = default)
        {
            var currentPoll = await GetAsync(id,cancellationToken);
            if (currentPoll is null)
                return false;
            currentPoll.Title = poll.Title;
            currentPoll.Summary = poll.Summary;
            currentPoll.StartsAt = poll.StartsAt;
            currentPoll.EndsAt= poll.EndsAt;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(int id,CancellationToken cancellationToken)
        {
            var poll = await GetAsync(id,cancellationToken);
            if (poll is null)
                return false;
            _dbContext.Remove(poll);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default)
        {
            var poll = await GetAsync(id,cancellationToken);
            if (poll is null)
                return false;
            poll.IsPublished = !poll.IsPublished;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
