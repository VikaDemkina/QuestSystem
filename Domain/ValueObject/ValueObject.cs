using System.Globalization;
using System.Text.RegularExpressions;

public abstract class ValueObject
{
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, null) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public ValueObject GetCopy()
    {
        return MemberwiseClone() as ValueObject;
    }
}

public class Address : ValueObject
{
    public string Value { get; }

    public Address(string value)
    {
        Value = value;
    }
    public static Address Of(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidAddressException();
        return new Address(value);
    }

    public static implicit operator string(Address address)
    {
        return address.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}

public class Price : ValueObject
{
    public decimal Value { get; }

    public Price(decimal value)
    {
        Value = value;
    }

    public static Price Of(decimal value)
    {
        if (value < 0) throw new InvalidPriceException();
        return new Price(value);
    }

    public static implicit operator decimal(Price price)
    {
        return price.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}

public class DateTime : ValueObject
{
    public string Value { get; }

    public DateTime(string value)
    {
        Value = value;
    }

    public static DateTime Of(string value)
    {
        if (System.DateTime.Parse(value) < System.DateTime.Now) throw new InvalidDateTimeException();
        return new DateTime(value);
    }

    public static implicit operator string(DateTime dateTime)
    {
        return dateTime.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}

public class OrderNumber : ValueObject
{
    public string Value { get; }

    public OrderNumber(string value)
    {
        Value = value;
    }

    public static OrderNumber Of(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new InvalidOrderNumberException();
        return new OrderNumber(value);
    }
    
    public static implicit operator string(OrderNumber orderNumber)
    {
        return orderNumber.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}

public class FinalPrice : ValueObject
{
    public decimal Value { get; }

    public FinalPrice(decimal value)
    {
        Value = value;
    }

    public static FinalPrice Of(decimal value)
    {
        if (value < 0) throw new InvalidFinalPriceException();
        return new FinalPrice(value);
    }

    public static implicit operator decimal(FinalPrice price)
    {
        return price.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}

public class UserName : ValueObject 
{
    public string FirstName { get; }
    public string LastName { get; }

    public UserName(string firstName, string lastName)
    {
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}

public class EmailAddress : ValueObject
{
    public string Email { get; set; }

    private EmailAddress()
    {
    }

    public EmailAddress(string value)
    {
        if (!IsValidEmail(value))
        {
            throw new InvalidEmailAddress();
        }

        Email = value;
    }
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Email;
    }

}