using AutoMapper;
using EcommerceApp.Comment.Context;
using EcommerceApp.Comment.Dtos.UserCommentDtos;
using EcommerceApp.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Comment.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserCommentsController(AppDbContext _context, IMapper _mapper) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllUserComments()
    {
        var values = _mapper.Map<List<ResultUserCommentDto>>(await _context.UserComments.ToListAsync());

        return Ok(values);
    }

    [HttpGet("GetCommentsByProductId")]
    public async Task<IActionResult> GetCommentsByProductId(string id)
    {
        var values = await _context.UserComments.Where(x => x.ProductId == id).ToListAsync();

        return Ok(_mapper.Map<List<ResultUserCommentDto>>(values));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserCommentById(int id)
    {
        var value = await _context.UserComments.FindAsync(id);

        return Ok(_mapper.Map<GetByIdUserCommentDto>(value));
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

        await _context.SaveChangesAsync();

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

    [HttpPatch]
    public async Task<IActionResult> ToggleStatus(int id)
    {
        var value = await _context.UserComments.FindAsync(id);

        value.Status = !value.Status;
        await _context.SaveChangesAsync();

        return Ok("Comment status changed successfully.");
    }
}
