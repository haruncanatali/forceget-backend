using Microsoft.EntityFrameworkCore;

namespace FORCEGET.Application.Common.Helpers;

public static class PaginationExtensions
{
    public async static Task<List<T>> 
        PagingListAsync<T>(this IQueryable<T> queryableEntities, 
            int page, int pageSize,CancellationToken token)
    {
        if (page == 0 || pageSize == 0)
        {
            return await queryableEntities.ToListAsync(token);
        }
        
        return await queryableEntities
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);
    }
}