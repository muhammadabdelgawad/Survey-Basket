using SurveyBasket.Api.Extentions;
using System.Security.Claims;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/polls/{pollId}/votes")]
    [ApiController]
    [Authorize]
    public class VotessController(IQuestionService questionService) : ControllerBase
    {
        private readonly IQuestionService _questionService = questionService;

        [HttpGet("")]
        public async Task<IActionResult> Start([FromBody] int pollId,CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();

            var result = await _questionService.GetAvailableAsync(pollId, userId!, cancellationToken);

            if (result.IsSuccess)
                return Ok(result.Value);

            return result.Error.Equals(VoteErrors.DuplicatedVote)
                ? result.ToProblem(StatusCodes.Status409Conflict)
                : result.ToProblem(StatusCodes.Status404NotFound);

        }
    }
}
