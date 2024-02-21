using ModularMonolith.Modules.Wallets.Core.Owners.SharedKernel;
using ModularMonolith.Modules.Wallets.Core.Owners.ValueObjects;

namespace ModularMonolith.Modules.Wallets.Core.Owners.Aggregates;

internal class Owner : AggregateRoot<OwnerId>
{
    public FullName FullName { get; private set; }
    public Nationality Nationality { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? VerifiedAt { get; private set; }
    public bool IsVerified => VerifiedAt.HasValue;

    protected Owner()
    {
    }

    public Owner(OwnerId id, FullName fullName, Nationality nationality, DateTime createdAt)
    {
        Id = id;
        FullName = fullName;
        Nationality = nationality;
        CreatedAt = createdAt;
    }

    public void Verify(DateTime verifiedAt)
    {
        if (IsVerified)
        {
            return;
        }
            
        VerifiedAt = verifiedAt;
        IncrementVersion();
    }
}