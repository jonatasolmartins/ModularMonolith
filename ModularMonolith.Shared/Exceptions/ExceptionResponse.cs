using System.Net;

namespace ModularMonolith.Shared.Exceptions;

public sealed record ExceptionResponse(ErrorsResponse Response, HttpStatusCode StatusCode);