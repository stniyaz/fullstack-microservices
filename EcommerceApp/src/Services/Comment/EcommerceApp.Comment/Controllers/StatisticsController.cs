using EcommerceApp.Comment.Context;
using EcommerceApp.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Comment.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class StatisticsController(AppDbContext _context) : ControllerBase
{
    [HttpGet("GetActiveUserCommentCount")]
    public async Task<IActionResult> GetActiveUserCommentCount()
    {
        var value = await _context.Set<UserComment>().Where(x => x.Status == true).CountAsync();

        return Ok(value);
    }

    [HttpGet("GetPassiveUserCommentCount")]
    public async Task<IActionResult> GetPassiveUserCommentCount()
    {
        var value = await _context.Set<UserComment>().Where(x => x.Status == false).CountAsync();

        return Ok(value);
    }

    [HttpGet("GetTotalUserCommentCount")]
    public async Task<IActionResult> GetTotalUserCommentCount()
    {
        var value = await _context.Set<UserComment>().CountAsync();

        return Ok(value);
    }
}
