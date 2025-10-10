using System.Runtime.Serialization;

namespace Adboard.AppServices.Exceptions;

public class NotFoundException : Exception
{
    public string NotFoundMessage { get; set; }
    
    public NotFoundException(string notFoundMessage)
    {
        NotFoundMessage = notFoundMessage;
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public NotFoundException(string? message, string notFoundMessage) : base(message)
    {
        NotFoundMessage = notFoundMessage;
    }

    public NotFoundException(string? message, Exception? innerException, string notFoundMessage) : base(message, innerException)
    {
        NotFoundMessage = notFoundMessage;
    }
}