namespace FORCEGET.Application.Common.Models;

public abstract class PaginatedData
{
    public int Total { get; set; }
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int PageCount => (int)Math.Ceiling(Total/(double)PageSize);
}