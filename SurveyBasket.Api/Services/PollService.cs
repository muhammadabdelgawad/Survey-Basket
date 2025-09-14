
namespace SurveyBasket.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls = [
            new Poll{ Id= 1, Tittle= "Poll 1", Description= "This is my first poll"}];

        public IEnumerable<Poll> GetAll() =>_polls;

        public Poll? Get(int id) =>_polls.SingleOrDefault(x => x.Id == id);

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count + 1;
           _polls.Add(poll);
            return poll;
        }
    }
}
