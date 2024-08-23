namespace Domain.Errors
{
    public sealed record Error(string Code, string Description)
    {
        public static readonly Error None = new(string.Empty, string.Empty); //noerror
        public static readonly Error NotFound = new("404", "Resource Not Found"); // common error
    }
}
