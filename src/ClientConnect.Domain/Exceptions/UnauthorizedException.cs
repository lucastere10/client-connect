namespace ClientConnect.Domain.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public string EntityType { get; }

        public UnauthorizedException(string entityType, string message) : base(message)
        {
            EntityType = entityType;
        }

        public UnauthorizedException(string entityType, string message, Exception innerException) : base(message, innerException)
        {
            EntityType = entityType;
        }
    }
}
