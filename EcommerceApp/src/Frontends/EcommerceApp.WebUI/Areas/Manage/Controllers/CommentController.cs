using EcommerceApp.DtoLayer.CommentDtos.UserCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EcommerceApp.WebUI.Areas.Manage.Controllers;

[Area("manage")]
public class CommentController(IHttpClientFactory _httpClientFactory) : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7075/api/usercomments/");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);

            return View(comments);
        }

        return View();
    }

    public async Task<IActionResult> Update(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:7075/usercomments/{id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var commentDto = JsonConvert.DeserializeObject<UpdateUserCommentDto>(jsonData);

            return View(commentDto);
        }

        return NotFound();
    }

    public async Task<IActionResult> ToggleStatus(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.PatchAsync($"https://localhost:7075/api/usercomments?id={id}", null);

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "comment", new { area = "manage" });
        }

        return NotFound();
    }
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:7075/api/usercomments?id={id}");

        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("index", "comment", new { area = "manage" });
        }

        return NotFound();
    }
}
