namespace ClientConnect.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public string EntityType { get; }

        public BadRequestException(string entityType, string message) : base(message)
        {
            EntityType = entityType;
        }

        public BadRequestException(string entityType, string message, Exception innerException) : base(message, innerException)
        {
            EntityType = entityType;
        }
    }
}
