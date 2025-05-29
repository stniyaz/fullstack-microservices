namespace EcommerceApp.DtoLayer.IdentityDtos.AccountDtos;

public class LoginDto
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
