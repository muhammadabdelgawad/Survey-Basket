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
        public IActionResult GetAll()
        {
            var polls = _pollService.GetAll();
            var response = polls.Adapt<IEnumerable<PollResponse>>();
            return Ok(response);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var poll = _pollService.Get(id);
            var response = poll.Adapt<PollResponse>();
            return poll is null ? NotFound() : Ok(response);
        } 

        [HttpPost]
        public IActionResult Add(CreatePollRequest request,
            [FromServices] IValidator<CreatePollRequest> validator)
        {
            var validationResult= validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var modelState = new ModelStateDictionary();
                validationResult.Errors.ForEach(x => modelState.AddModelError(x.PropertyName, x.ErrorMessage));

            }
            var newPoll = _pollService.Add(request.Adapt<Poll>());
            return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreatePollRequest request)
        {
            var isUpdated = _pollService.Update(id, request.Adapt<Poll>());
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
