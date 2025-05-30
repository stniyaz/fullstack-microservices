using System.Security.Claims;

namespace EcommerceApp.WebUI.Services.LoginServices;

public class LoginService(IHttpContextAccessor _contextAccessor) : ILoginService
{
    public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
}
