namespace SurveyBasket.Services
{
    public interface IPollService
    {
        IEnumerable<Poll> GetAll();
        Poll? Get(int id);
        Poll Add(Poll poll);

    }
}
