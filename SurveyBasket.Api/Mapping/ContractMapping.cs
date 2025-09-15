using SurveyBasket.Contracts.Requests;
using SurveyBasket.Contracts.Responses;

namespace SurveyBasket.Mapping
{
    public static class ContractMapping
    {
        public static PollResponse MapToResponse(this Poll poll)
        {
            return new()
            {
                Id = poll.Id,
                Tittle = poll.Tittle,
                Description = poll.Description
            };
        }

        public static IEnumerable<PollResponse> MapToResponse(this IEnumerable<Poll> polls)
        {
            return polls.Select(MapToResponse);
        }

        public static Poll MapToPoll(this CreatePollRequest request)
        {
            return new()
            {
                Tittle = request.Tittle,
                Description = request.Description
            };
        }



    }
}
