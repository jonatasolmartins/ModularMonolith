using System;

namespace ModularMonolith.Modules.Users.Shared.Events;

public record UserVerified(Guid UserId, string Email, string Nationality);