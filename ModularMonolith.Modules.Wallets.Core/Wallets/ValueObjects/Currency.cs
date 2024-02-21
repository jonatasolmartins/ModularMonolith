using ModularMonolith.Modules.Wallets.Core.Wallets.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Wallets.ValueObjects;

internal sealed class Currency : IEquatable<Currency>
{
    private static readonly HashSet<string> AllowedValues = new()
    {
        "PLN", "EUR", "GBP", "USD", "PGY", "JPY", "CNY", "BRL", "CAD"
    };

    public string Value { get; }
        
    public Currency(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 3)
        {
            throw new InvalidCurrencyException(value);
        }

        value = value.ToUpperInvariant();
        if (!AllowedValues.Contains(value))
        {
            throw new UnsupportedCurrencyException(value);
        }
            
        Value = value;
    }
        
    public static implicit operator Currency(string value) => new(value);

    public static implicit operator string(Currency value) => value.Value;
        
    public static bool operator ==(Currency a, Currency b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a is not null && b is not null)
        {
            return a.Value.Equals(b.Value);
        }

        return false;
    }

    public static bool operator !=(Currency a, Currency b) => !(a == b);

    public bool Equals(Currency? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Currency)obj);
    }

    public override int GetHashCode() => !string.IsNullOrEmpty(Value) ? Value.GetHashCode() : 0;

    public override string ToString() => Value;
}