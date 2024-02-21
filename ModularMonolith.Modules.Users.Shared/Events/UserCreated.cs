using ModularMonolith.Shared.Events;

namespace ModularMonolith.Modules.Users.Shared.Events;

public record UserCreated(Guid UserId, string Email, string FullName, string Nationality) : IEvent;