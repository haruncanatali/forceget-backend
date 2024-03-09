using System.Security.Claims;
using FORCEGET.Application.Common.Interfaces;

namespace FORCEGET.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        string UserIdStr = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        UserId = Convert.ToInt64(UserIdStr);
        IsAuthenticated = UserId != null;
    }

    public long UserId { get; }
    public bool IsAuthenticated { get; }
}