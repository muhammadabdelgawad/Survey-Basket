namespace SurveyBasket.Abstractions
{
    public record Error(string Code,string Descripton)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}
