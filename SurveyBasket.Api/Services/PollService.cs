
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
            return true;
        }

        //public bool Delete(int id)
        //{
        //    var poll = Get(id);
        //    if (poll is null)
        //        return false;
        //    _polls.Remove(poll);
        //    return true;
        //}
    }
}
