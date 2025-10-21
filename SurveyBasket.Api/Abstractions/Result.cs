namespace SurveyBasket.Abstractions
{
    public class Result
    {
        public bool IsSuccess { get;}
        public bool IsFailure => !IsSuccess;    
        public Error Error { get;} = default!;
    }
}
