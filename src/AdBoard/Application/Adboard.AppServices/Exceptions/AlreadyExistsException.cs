using System.Runtime.Serialization;

namespace Adboard.AppServices.Exceptions;

public class AlreadyExistsException : Exception
{
    public string AlreadyExistMessage { get; set; }
    
    public AlreadyExistsException(string alreadyExistMessage)
    {
        AlreadyExistMessage = alreadyExistMessage;
    }

    protected AlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public AlreadyExistsException(string? message, string alreadyExistMessage) : base(message)
    {
        AlreadyExistMessage = alreadyExistMessage;
    }

    public AlreadyExistsException(string? message, Exception? innerException, string alreadyExistMessage) : base(message, innerException)
    {
        AlreadyExistMessage = alreadyExistMessage;
    }
}