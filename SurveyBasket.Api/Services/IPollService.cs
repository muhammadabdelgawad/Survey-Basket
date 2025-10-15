﻿namespace SurveyBasket.Services
{
    public interface IPollService
    {
        Task<IEnumerable<Poll>> GetAllAsync();

        Task<Poll?> GetAsync(int id);
        Task <Poll> AddAsync(Poll poll , CancellationToken cancellationToken = default);
        //bool Update(int id, Poll poll);
        //bool Delete(int id);

    }
}
