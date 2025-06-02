using EcommerceApp.DtoLayer.IdentityDtos.AccountDtos;
using EcommerceApp.WebUI.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Controllers;

public class AccountController(IHttpClientFactory _httpClientFactory,
                               IAccountService _accountService) : Controller
{
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(registerDto);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:5001/api/accounts/", content);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "home");
        }

        return View(registerDto);
    }

    public async Task<IActionResult> Login()
    {
        await _accountService.LoginAsync(new LoginDto
        {
            Username = "niyazstv",
            Password = "Salam123!!"
        });

        return RedirectToAction("index", "profile");
    }
    //[HttpPost]
    //public async Task<IActionResult> Login(LoginDto loginDto)
    //{
    //    var client = _httpClientFactory.CreateClient();
    //    var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
    //    var responseMessage = await client.PostAsync("http://localhost:5001/api/accounts/signin/", content);

    //    if (responseMessage.IsSuccessStatusCode)
    //    {
    //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
    //        var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
    //        {
    //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    //        });

    //        if (tokenModel is not null)
    //        {
    //            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
    //            var token = handler.ReadJwtToken(tokenModel.Token);
    //            var claims = token.Claims.ToList();

    //            if (tokenModel.Token is not null)
    //            {
    //                claims.Add(new Claim("EcommerceAppToken", tokenModel.Token));
    //                var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
    //                var authProps = new AuthenticationProperties
    //                {
    //                    ExpiresUtc = tokenModel.ExpireDate,
    //                    IsPersistent = true
    //                };

    //                await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

    //                return RedirectToAction("index", "home");
    //            }
    //        }
    //    }
    //    return View(loginDto);
    //}
}
