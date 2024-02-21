using ModularMonolith.Modules.Wallets.Core.Owners.Exceptions;

namespace ModularMonolith.Modules.Wallets.Core.Owners.ValueObjects;

internal sealed class FullName : IEquatable<FullName>
{
    private string Value { get; }
        
    public FullName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 100 or < 2)
        {
            throw new InvalidFullNameException(value);
        }
            
        Value = value;
    }

    public static implicit operator FullName(string value) => (string.IsNullOrEmpty(value) ? null : new FullName(value))!;

    public static implicit operator string(FullName value) => value?.Value;

    public bool Equals(FullName? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((FullName)obj);
    }

    public override int GetHashCode() => !string.IsNullOrEmpty(Value) ? Value.GetHashCode() : 0;
        
    public override string ToString() => Value;
}