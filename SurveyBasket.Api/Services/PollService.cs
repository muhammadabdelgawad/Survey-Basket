
namespace SurveyBasket.Services
{
    public class PollService(AppDbContext context) : IPollService
    {private readonly AppDbContext _dbContext = context;

        public async Task<IEnumerable<Poll>> GetAllAsync()
            => await _dbContext.Polls.AsNoTracking().ToListAsync();

        public async Task<Poll?> GetAsync(int id) =>await  _dbContext.Polls.FindAsync(id);

        public async Task<Poll> AddAsync(Poll poll)
        {
            await _dbContext.Polls.AddAsync(poll);
            await _dbContext.SaveChangesAsync();
            return poll;
        }

        //public bool Update(int id, Poll poll)
        //{
        //   var currentPoll = Get(id);
        //    if (currentPoll is null) 
        //        return false;
        //    currentPoll.Tittle = poll.Tittle;
        //    currentPoll.Summary = poll.Summary;
        //    return true;
        //}

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
