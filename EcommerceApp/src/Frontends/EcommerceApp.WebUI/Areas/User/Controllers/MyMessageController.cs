using EcommerceApp.WebUI.Services.MessageServices.UserMessageServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.User.Controllers;

[Area("user")]
public class MyMessageController(IUserMessageService _userMessageService) : Controller
{
    public async Task<IActionResult> Inbox()
    {
        var values = await _userMessageService.GetInboxMessagesAsync("user2");

        return View(values);
    }

    public async Task<IActionResult> Sendbox()
    {
        var values = await _userMessageService.GetSendboxMessagesAsync("user1");

        return View(values);
    }
}
