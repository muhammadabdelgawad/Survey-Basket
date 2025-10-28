using Microsoft.AspNetCore.Authorization;

namespace SurveyBasket.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PollsController(IPollService pollService, IMapper mapper) : ControllerBase
    {
        private readonly IPollService _pollService = pollService;
        private readonly IMapper _mapper = mapper;

        [HttpGet()]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var polls = await _pollService.GetAllAsync(cancellationToken);
            var response = polls.Adapt<IEnumerable<PollResponse>>();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id, CancellationToken cancellationToken)
        {
            var result = await _pollService.GetAsync(id,cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] PollRequest request,CancellationToken cancellationToken)
        {
            var newPoll = await _pollService.AddAsync(request.Adapt<Poll>(),cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll.Adapt<PollResponse>());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PollRequest request,CancellationToken cancellationToken)
        {
            var isUpdated = await _pollService.UpdateAsync(id, request.Adapt<Poll>(),cancellationToken);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var isDeleted =await _pollService.DeleteAsync(id,cancellationToken);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/togglePublish")]
        public async Task<IActionResult> TogglePublish(int id,CancellationToken cancellationToken)
        {
            var isUpdated = await _pollService.TogglePublishStatusAsync(id,cancellationToken);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }




    }
}
