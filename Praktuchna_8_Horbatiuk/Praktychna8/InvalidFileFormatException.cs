using System;

namespace Praktychna8;

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
