
using SurveyBasket.Application.Abstractions.DTOs.Questions.Requests;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/polls/{pollId}/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController(IQuestionService questionService) : ControllerBase
    {
        private readonly IQuestionService _questionService = questionService;

        [HttpPost("")]
        public async Task<IActionResult> Add([FromRoute] int pollId, [FromBody] QuestionRequest request, CancellationToken cancellationToken)
        {
            var result = await _questionService.AddAsync(pollId, request, cancellationToken);

            if (result.IsSuccess)
                return CreatedAtAction(nameof(Get), new { pollId, result.Value.Id }, result.Value);

            return result.Error.Equals(QuestionErrors.DuplicatedQuestionContent)
                    ? result.ToProblem(StatusCodes.Status409Conflict)
                    : result.ToProblem(StatusCodes.Status404NotFound);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int pollId, [FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _questionService.GetAsync(pollId, id, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem(StatusCodes.Status404NotFound);
        }
    }
}
