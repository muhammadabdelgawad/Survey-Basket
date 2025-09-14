using SurveyBasket.Services;

namespace SurveyBasket.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase
    {
        private readonly IPollService _pollService = pollService;

        [HttpGet("TestGet")]
        public IActionResult GetAll()
        {
            return Ok(_pollService.GetAll());
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var polls =_pollService.Get(id);
            return polls is null ? NotFound() : Ok(polls);
        }

        [HttpPost]
        public IActionResult Add(Poll request) 
        {
            var newPoll= _pollService.Add(request);
            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }






    }
}
