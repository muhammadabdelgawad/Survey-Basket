﻿namespace SurveyBasket.Contracts.Requests
{
    public record PollRequest(
        string Title,
        string Summary,
        bool Ispublished,
        DateOnly StartsAt,
        DateOnly EndsAt
    );
}
