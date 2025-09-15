namespace SurveyBasket.Contracts.Requests
{
    public class CreatePollRequest
    {
        public string Tittle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
