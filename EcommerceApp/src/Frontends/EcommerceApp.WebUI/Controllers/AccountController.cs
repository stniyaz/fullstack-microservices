using EcommerceApp.DtoLayer.IdentityDtos.AccountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Controllers;

public class AccountController(IHttpClientFactory _httpClientFactory) : Controller
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

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var client = _httpClientFactory.CreateClient();

        return View(loginDto);
    }
}
