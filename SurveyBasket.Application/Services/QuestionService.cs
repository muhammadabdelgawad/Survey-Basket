using Microsoft.EntityFrameworkCore;

namespace SurveyBasket.Application.Services
{
    public class QuestionService(AppDbContext dbContext) : IQuestionService
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<Result<QuestionResponse>> AddAsync(int pollId, QuestionRequest request, CancellationToken cancellationToken = default)
        {
            var pollIsExists = await _dbContext.Polls.AnyAsync(x => x.Id == pollId, cancellationToken: cancellationToken);

            if (!pollIsExists)
                return Result.Failure<QuestionResponse>(PollErrors.PollNotFound);

            var questionIsExists = await _dbContext.Questions.AnyAsync(x => x.Content == request.Content && x.PollId == pollId, cancellationToken: cancellationToken);

            if (questionIsExists)
                return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestionContent);

            var question = request.Adapt<Question>();
            question.PollId = pollId;

            await _dbContext.AddAsync(question, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success(question.Adapt<QuestionResponse>());
        }

        public Task<Result<QuestionResponse>> UpdateAsync(QuestionRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


        public Task<Result<IEnumerable<QuestionResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<QuestionResponse>> GetAsync(int pollId, int id, CancellationToken cancellationToken = default)
        {
            var question = await _dbContext.Questions
                .Where(x => x.PollId == pollId && x.Id == id)
                .Include(x => x.Answers)
                .ProjectToType<QuestionResponse>()
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);

            if (question is null)
                return Result.Failure<QuestionResponse>(QuestionErrors.QuestionNotFound);

            return Result.Success(question);
        }
        public Task Delete(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        
    }
}
