namespace LyResult;

public static class Extensions
{
    public static Result<T> Ensure<T>(this Result<T> result,
        Func<T, bool> predicate, Error error)
    {
        if (result.IsFailure)
            return result;

        return predicate(result.Value)
            ? result
            : Result.Failure<T>(error);
    }

    public static Result<T> Map<T>(this Result<T> result,
        Action<T> action)
    {
        if (result.IsSuccess)
            action(result.Value);

        return result;
    }

    public static async Task<Result<T>> Bind<T, TPrevious>(
        this Result<TPrevious> result,
        Func<TPrevious, Task<Result<T>>> func)
    {
        if (result.IsFailure)
            return Result.Failure<T>(result.Error);

        return await func(result.Value);
    }

    public static Result Combine(params Result[] results)
    {
        foreach (var result in results)
        {
            if (result.IsFailure)
                return result;
        }

        return Result.Success();
    }
}