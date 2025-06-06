using EcommerceApp.WebUI.Services.MessageServices.UserMessageServices;
using EcommerceApp.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.User.Controllers;

[Area("user")]
public class MyMessageController(IUserMessageService _userMessageService,
                                 IUserService _userService) : Controller
{
    public async Task<IActionResult> Inbox()
    {
        var userInfo = await _userService.GetUserInfoAsync();
        var values = await _userMessageService.GetInboxMessagesAsync(userInfo.Id);

        return View(values);
    }

    public async Task<IActionResult> Sendbox()
    {
        var userInfo = await _userService.GetUserInfoAsync();
        var values = await _userMessageService.GetSendboxMessagesAsync(userInfo.Id);

        return View(values);
    }
}
