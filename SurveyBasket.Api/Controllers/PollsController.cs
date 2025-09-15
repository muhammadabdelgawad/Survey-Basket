using SurveyBasket.Contracts.Requests;
using SurveyBasket.Mapping;
using SurveyBasket.Services;

namespace SurveyBasket.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase
    {
        private readonly IPollService _pollService = pollService;

        [HttpGet()]
        public IActionResult GetAll()
        {
            var polls = _pollService.GetAll();  
            return Ok(polls.MapToResponse());
        } 


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var poll =_pollService.Get(id);
            return poll is null ? NotFound() : Ok(poll.MapToResponse());
        }

        [HttpPost]
        public IActionResult Add(CreatePollRequest request) 
        {
            var newPoll= _pollService.Add(request.MapToPoll());
            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreatePollRequest request)
        {
            var isUpdated = _pollService.Update(id, request.MapToPoll());
            if (!isUpdated)
                return NotFound();
                        
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleted = _pollService.Delete(id);
            if (!isDeleted)
                return NotFound();
            return NoContent();
        }
            





    }
}
