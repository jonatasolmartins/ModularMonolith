namespace ModularMonolith.Shared.Exceptions;

public record Error(string Code, string Message);

public record ErrorsResponse(params Error[] Errors);