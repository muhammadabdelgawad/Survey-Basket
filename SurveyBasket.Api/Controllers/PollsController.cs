using MapsterMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SurveyBasket.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService/*, IMapper mapper*/) : ControllerBase
    {
        private readonly IPollService _pollService = pollService;
        //private readonly IMapper _mapper = mapper;

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
            var poll = await _pollService.GetAsync(id,cancellationToken);
            var response = poll.Adapt<PollResponse>();
            return poll is null ? NotFound() : Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CreatePollRequest request,CancellationToken cancellationToken)
        {
            var newPoll = await _pollService.AddAsync(request.Adapt<Poll>(),cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, CreatePollRequest request)
        //{
        //    var isUpdated = _pollService.Update(id, request.Adapt<Poll>());
        //    if (!isUpdated)
        //        return NotFound();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var isDeleted = _pollService.Delete(id);
        //    if (!isDeleted)
        //        return NotFound();
        //    return NoContent();
        //}






    }
}
