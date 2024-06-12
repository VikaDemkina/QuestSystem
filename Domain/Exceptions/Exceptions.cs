using QuestSystem.Domain.Exceptions;

public class InvalidAddressException : BadRequestException
{
    public InvalidAddressException() : base("Address cannot be empty or whitespace.")
    {
    }
}

public class InvalidPriceException : BadRequestException
{
    public InvalidPriceException() : base("The price of booking cannot be negative.")
    {
    }
}

public class InvalidDateTimeException : BadRequestException
{
    public InvalidDateTimeException() : base("The date cannot be in the past tense!.")
    {
    }
}

public class InvalidOrderNumberException : BadRequestException
{
    public InvalidOrderNumberException() : base("Address cannot be empty or whitespace.")
    {
    }
}

public class InvalidFinalPriceException : BadRequestException
{
    public InvalidFinalPriceException() : base("The price of booking cannot be negative.")
    {
    }
}

public class InvalidEmailAddress : BadRequestException
{
    public InvalidEmailAddress() : base("Invalid email address")
    {
    }
}
