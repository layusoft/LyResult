namespace LyResult;

public record Error
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");

    public Error(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public string Code { get; }
    public string Description { get; }

    public static Error NotFound(string description) =>
        new("Error.NotFound", description);

    public static Error Validation(string description) =>
        new("Error.Validation", description);

    public static Error Conflict(string description) =>
        new("Error.Conflict", description);

    public static Error Unauthorized(string description = "You are not authorized") =>
        new("Error.Unauthorized", description);

    public static Error Forbidden(string description = "You don't have permission") =>
        new("Error.Forbidden", description);
}