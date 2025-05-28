using AutoMapper;
using EcommerceApp.Comment.Context;
using EcommerceApp.Comment.Dtos.UserCommentDtos;
using EcommerceApp.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Comment.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class CommentsController(AppDbContext _context, IMapper _mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllUserComments()
    {
        var values = await _context.UserComments.ToListAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllUserComments(int id)
    {
        var values = await _context.UserComments.ToListAsync();

        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserComment(CreateUserCommentDto dto)
    {
        await _context.UserComments.AddAsync(_mapper.Map<UserComment>(dto));

        await _context.SaveChangesAsync();

        return StatusCode(201, "User comment created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserComment(UpdateUserCommentDto dto)
    {
        _context.UserComments.Update(_mapper.Map<UserComment>(dto));

        return Ok("User comment updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserComment(int id)
    {
        var value = await _context.UserComments.FindAsync(id);
        _context.UserComments.Remove(value);
        await _context.SaveChangesAsync();

        return Ok("User comment deleted successfully.");
    }
}

