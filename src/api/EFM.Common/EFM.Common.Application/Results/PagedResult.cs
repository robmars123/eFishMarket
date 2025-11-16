namespace EFM.Common.Application.Results;
public sealed class PagedResult<T>: Result
{
    public IReadOnlyList<T> Items { get; }
    public int TotalCount { get; }

    private PagedResult(bool isSuccess, string? error, IReadOnlyList<T> items, int totalCount)
        : base(isSuccess, error)
    {
        Items = items;
        TotalCount = totalCount;
    }

    public static PagedResult<T> Success(IReadOnlyList<T> items, int totalCount) =>
        new PagedResult<T>(true, null, items, totalCount);

    public static PagedResult<T> Failure(string error) =>
        new PagedResult<T>(false, error, Array.Empty<T>(), 0);
}

public sealed class PagedResponse<T> : Result
{
    public IReadOnlyList<T> Items { get; }
    public int TotalCount { get; }
    public int Page { get; }
    public int PageSize { get; }

    private PagedResponse(bool isSuccess, string? error,
        IReadOnlyList<T> items, int totalCount, int page, int pageSize)
        : base(isSuccess, error)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }

    public static PagedResponse<T> Success(IReadOnlyList<T> items, int totalCount, int page, int pageSize) =>
        new PagedResponse<T>(true, null, items, totalCount, page, pageSize);

    public static PagedResponse<T> Failure(string error) =>
        new PagedResponse<T>(false, error, Array.Empty<T>(), 0, 0, 0);
}
