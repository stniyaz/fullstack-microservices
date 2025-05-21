namespace EcommerceApp.Basket.Services.LoginServices;

public class LoginService(IHttpContextAccessor _context) : ILoginService
{
    public string GetUserId => _context.HttpContext.User.FindFirst("sub").Value;
}
