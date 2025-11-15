
using SurveyBasket.Application.Abstractions.DTOs.Questions.Requests;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/poll/{pollId}/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionsController(IQuestionService questionService) : ControllerBase
    {
        private readonly IQuestionService _questionService = questionService;

        [HttpPost("")]
        public async Task<IActionResult> Add([FromRoute] int pollId, QuestionRequest request, CancellationToken cancellationToken)
        { 

        }

    }
}
