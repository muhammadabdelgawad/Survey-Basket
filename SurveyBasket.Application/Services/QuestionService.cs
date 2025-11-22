using SurveyBasket.Application.Abstractions.DTOs.Answers;
using SurveyBasket.Application.Abstractions.DTOs.Polls.Responses;
using AutoMapper;

namespace SurveyBasket.Application.Services
{
    public class QuestionService(AppDbContext dbContext) : IQuestionService  // Remove IMapper parameter
    {
        private readonly AppDbContext _dbContext = dbContext;
        // Remove: private readonly IMapper _mapper = mapper;


        public async Task<Result<IEnumerable<QuestionResponse>>> GetAllAsync(int pollId, CancellationToken cancellationToken = default)
        {
            var pollIsExists = await _dbContext.Polls.AnyAsync(x => x.Id == pollId, cancellationToken: cancellationToken);

            if (!pollIsExists)
                return Result.Failure<IEnumerable<QuestionResponse>>(PollErrors.PollNotFound);

            var questions = await _dbContext.Questions
                .Where(x => x.PollId == pollId)
                .Include(x => x.Answers)
                //.Select(q => new QuestionResponse(
                //    q.Id,
                //    q.Content,
                //    q.Answers.Select(a => new AnswerResponse(a.Id, a.Content))
                //))
                .ProjectToType<QuestionResponse>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return Result.Success<IEnumerable<QuestionResponse>>(questions);
        }
       
        public async Task<Result<IEnumerable<QuestionResponse>>> GetAvailableAsync(int pollId, string userId, CancellationToken cancellationToken = default)
        {
            var isVoted = await _dbContext.Votes.AnyAsync(v => v.PollId == pollId && v.UserId == userId ,cancellationToken);
            if (isVoted)
                return Result.Failure<IEnumerable<QuestionResponse>>(VoteErrors.DuplicatedVote);

            var pollExists = await _dbContext.Polls.AnyAsync(p => p.Id == pollId && p.IsPublished && p.StartsAt <= DateOnly.FromDateTime(DateTime.UtcNow) && p.EndsAt >= DateOnly.FromDateTime(DateTime.UtcNow));
          
            if (!pollExists)
                return Result.Failure<IEnumerable<QuestionResponse>>(PollErrors.PollNotFound);

            var questions = await _dbContext.Questions
                .Where(q => q.PollId == pollId && q.IsActive)
                .Include(x => x.Answers)
                .Select(q => new QuestionResponse(
                    q.Id,
                    q.Content,
                    q.Answers
                        .Where(a => a.IsActive)
                        .Select(a => new AnswerResponse(a.Id, a.Content))
                )).AsNoTracking().ToListAsync(cancellationToken);

            return Result.Success<IEnumerable<QuestionResponse>>(questions);

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

        public async Task<Result<QuestionResponse>> AddAsync(int pollId, QuestionRequest request, CancellationToken cancellationToken = default)
        {
            var pollIsExists = await _dbContext.Polls.AnyAsync(x => x.Id == pollId, cancellationToken: cancellationToken);

            if (!pollIsExists)
                return Result.Failure<QuestionResponse>(PollErrors.PollNotFound);

            var questionIsExists = await _dbContext.Questions.AnyAsync(x => x.Content == request.Content && x.PollId == pollId, cancellationToken: cancellationToken);

            if (questionIsExists)
                return Result.Failure<QuestionResponse>(QuestionErrors.DuplicatedQuestionContent);

            // ✅ Use Mapster (via extension method)
            var question = request.Adapt<Question>();
            question.PollId = pollId;

            await _dbContext.AddAsync(question, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // Reload the question with answers to get the generated IDs
            var savedQuestion = await _dbContext.Questions
                .Include(q => q.Answers)
                .FirstAsync(q => q.Id == question.Id, cancellationToken);

            // ✅ Use Mapster
            return Result.Success(savedQuestion.Adapt<QuestionResponse>());
        }


        public async Task<Result> UpdateAsync(int pollId, int id, QuestionRequest request, CancellationToken cancellationToken = default)
        {
            var questionIsExists = await _dbContext.Questions
                .AnyAsync(x => x.PollId == pollId
                    && x.Id != id
                    && x.Content == request.Content,
                    cancellationToken
                );

            if (questionIsExists)
                return Result.Failure(QuestionErrors.DuplicatedQuestionContent);

            var question = await _dbContext.Questions
                .Include(x => x.Answers)
                .SingleOrDefaultAsync(x => x.PollId == pollId && x.Id == id, cancellationToken);

            if (question is null)
                return Result.Failure(QuestionErrors.QuestionNotFound);

            question.Content = request.Content;

            var currentAnswers = question.Answers.Select(x => x.Content).ToList();

            var newAnswers = request.QuestionAnswers.Except(currentAnswers).ToList();

            newAnswers.ForEach(answer =>
            {
                question.Answers.Add(new Answer { Content = answer });
            });

            question.Answers.ToList().ForEach(answer =>
            {
                answer.IsActive = request.QuestionAnswers.Contains(answer.Content);
            });

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result> ToggleStatusAsync(int pollId, int id, CancellationToken cancellationToken = default)
        {
            var question = await _dbContext.Questions.SingleOrDefaultAsync(x => x.PollId == pollId && x.Id == id, cancellationToken);

            if (question is null)
                return Result.Failure(QuestionErrors.QuestionNotFound);

            question.IsActive = !question.IsActive;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

    }
}
