using EcommerceApp.WebUI.Services.CommentServices.UserCommentServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class CommentController(IUserCommentService _userCommentService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var values = await _userCommentService.GetAllCommentsAsync();

        return View(values);
    }

    //public async Task<IActionResult> Update(int id)
    //{
    //    var client = _httpClientFactory.CreateClient();
    //    var responseMessage = await client.GetAsync($"https://localhost:7075/usercomments/{id}");

    //    if (responseMessage.IsSuccessStatusCode)
    //    {
    //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
    //        var commentDto = JsonConvert.DeserializeObject<UpdateUserCommentDto>(jsonData);

    //        return View(commentDto);
    //    }

    //    return NotFound();
    //}

    public async Task<IActionResult> ToggleStatus(int id)
    {
        await _userCommentService.ToggleUserCommentStatusAsync(id);

        return RedirectToAction("index", "comment", new { area = "manage" });
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _userCommentService.DeleteUserCommentAsync(id);

        return RedirectToAction("index", "comment", new { area = "manage" });
    }
}
