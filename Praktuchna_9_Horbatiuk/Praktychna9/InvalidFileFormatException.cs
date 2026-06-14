using System;

namespace Praktychna9;

public class InvalidFileFormatException : Exception
{
    public InvalidFileFormatException(string message) : base(message)
    {
    }

    public InvalidFileFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
