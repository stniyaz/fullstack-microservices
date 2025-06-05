using EcommerceApp.Message.Dtos.UserMessageDtos;
using EcommerceApp.Message.Services.UserMessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Message.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserMessagesController(IUserMessageService _userMessageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUserMessages()
    {
        var values = await _userMessageService.GetAllUserMessagesAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserMessageById(int id)
    {
        var value = await _userMessageService.GetUserMessageByIdAsync(id);

        return Ok(value);
    }

    [HttpGet("GetInboxMessages")]
    public async Task<IActionResult> GetInboxMessages(string id)
    {
        var values = await _userMessageService.GetInboxMessagesAsync(id);

        return Ok(values);
    }

    [HttpGet("GetSendboxMessages")]
    public async Task<IActionResult> GetSendboxMessages(string id)
    {
        var values = await _userMessageService.GetSendboxMessagesAsync(id);

        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserMessage(CreateUserMessageDto dto)
    {
        await _userMessageService.CreateUserMessageAsync(dto);

        return StatusCode(201, "User message created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserMessage(UpdateUserMessageDto dto)
    {
        await _userMessageService.UpdateUserMessageAsync(dto);

        return Ok("User message updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserMessage(int id)
    {
        await _userMessageService.DeleteUserMessageAsync(id);

        return Ok("User message deleted successfully.");
    }
}
