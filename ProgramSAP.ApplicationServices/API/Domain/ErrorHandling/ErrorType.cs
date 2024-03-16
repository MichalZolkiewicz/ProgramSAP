namespace ProgramSAP.ApplicationServices.API.Domain.ErrorHandling;

public static class ErrorType
{
    public const string InternalSeverError = "INTERNAL_SERVER_ERROR";

    public const string NotFound = "NOT_FOUND";

    public const string EmptyOrNullRequest = "EMPTY_OR_NULL_REQUEST";

    public const string RequestTooLarge = "REQUEST_TOO_LARGE";

    public const string TooManyRequests = "TOO_MANY_REQUESTS";

    public const string ValidationError = "VALIDATION_ERROR";

    public const string NotAuthenticated = "NOT_AUTHENTICATED";

    public const string Unauthorized = "UNAUTHORIZED";
}
