﻿namespace SurveyBasket.Contracts.Responses
{
    public class PollResponse
    {
        public int Id { get; set; }
        public string Tittle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
