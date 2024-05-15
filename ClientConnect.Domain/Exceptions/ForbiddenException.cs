namespace ClientConnect.Domain.Exceptions
{
    public class ForbiddenException : Exception
    {
        public string EntityType { get; }

        public ForbiddenException(string entityType, string message) : base(message)
        {
            EntityType = entityType;
        }

        public ForbiddenException(string entityType, string message, Exception innerException) : base(message, innerException)
        {
            EntityType = entityType;
        }
    }
}
