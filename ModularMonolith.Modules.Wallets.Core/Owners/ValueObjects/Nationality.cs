using ModularMonolith.Modules.Wallets.Core.Owners.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Owners.ValueObjects;

internal sealed class Nationality : IEquatable<Nationality>
{
    private static readonly HashSet<string> AllowedValues = new()
    {
        "PL", "DE", "FR", "ES", "GB", "US", "CA", "AU", "NZ", "JP", "CN", "KR", "RU", "BR", "BO", "AR", "CL", "PY", "VE", "ZA", "NG",
    };

    private string Value { get; }
        
    public Nationality(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 2)
        {
            throw new InvalidNationalityException(value);
        }

        value = value.ToUpperInvariant();
        if (!AllowedValues.Contains(value))
        {
            throw new UnsupportedNationalityException(value);
        }
            
        Value = value;
    }
        
    public static implicit operator Nationality(string value) => (string.IsNullOrEmpty(value) ? null : new Nationality(value))!;

    public static implicit operator string(Nationality value) => value?.Value;

    public bool Equals(Nationality? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Nationality)obj);
    }

    public override int GetHashCode() =>  !string.IsNullOrEmpty(Value) ? Value.GetHashCode() : 0;
        
    public override string ToString() => Value;
}