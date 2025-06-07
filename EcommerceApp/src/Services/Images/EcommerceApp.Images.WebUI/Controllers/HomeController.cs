using EcommerceApp.Images.WebUI.DAL.Entities;
using EcommerceApp.Images.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Images.WebUI.Controllers;

public class HomeController : Controller
{

    private readonly ICloudStorageService _cloudStorageService;

    public HomeController(ICloudStorageService cloudStorageService)
    {
        _cloudStorageService = cloudStorageService;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ImageDrive imageDrive)
    {
        if (imageDrive.Photo != null)
        {
            imageDrive.SavedFileName = GenerateFileNameToSave(imageDrive.Photo.FileName);
            imageDrive.SavedUrl = await _cloudStorageService.UploadFileAsync(imageDrive.Photo, imageDrive.SavedFileName);
        }
        return RedirectToAction("create", "home");
    }


    private string? GenerateFileNameToSave(string incomingFileName)
    {
        var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
        var extension = Path.GetExtension(incomingFileName);
        return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
    }

}

