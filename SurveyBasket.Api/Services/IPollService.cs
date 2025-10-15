namespace SurveyBasket.Services
{
    public interface IPollService
    {
        Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken);

        Task<Poll?> GetAsync(int id, CancellationToken cancellationToken);
        Task <Poll> AddAsync(Poll poll , CancellationToken cancellationToken = default);
        //bool Update(int id, Poll poll);
        //bool Delete(int id);

    }
}
