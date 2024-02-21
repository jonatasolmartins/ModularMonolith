namespace ModularMonolith.Modules.Wallets.Core.Wallets.ValueObjects;

internal sealed class WalletId(Guid value) : IEquatable<WalletId>
{
    private Guid Value { get; } = value;

    public WalletId() : this(Guid.NewGuid())
    {
    }

    public bool Equals(WalletId? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((WalletId)obj);
    }

    public override int GetHashCode() => Value.GetHashCode();
        
    public override string ToString() => Value.ToString();
        
    public static implicit operator WalletId(Guid value) => new(value);

    public static implicit operator Guid(WalletId value) => value.Value;
}