using Microsoft.AspNetCore.Diagnostics;

namespace ClientConnect.Api.ExceptionHandler;

public class ExceptionLogginHandler : IExceptionHandler
{
    private readonly ILogger _logger;
    public ExceptionLogginHandler(ILogger<ExceptionLogginHandler> logger)
    {
        _logger = logger;
    }
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionMessage = exception.Message;

        _logger.LogError(
            "Message with TraceId {traceId} failed with message: {exceptionMessage}",
            httpContext.TraceIdentifier, exceptionMessage, DateTime.UtcNow);

        return ValueTask.FromResult(false);
    }
}
