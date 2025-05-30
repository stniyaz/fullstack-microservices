using EcommerceApp.Catalog.Dtos.SpecialOfferDtos;
using EcommerceApp.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Catalog.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class SpecialOffersController(ISpecialOfferService _specialOfferService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllSpecialOffers()
    {
        var values = await _specialOfferService.GetAllSpecialOffersAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSpecialOfferById(string id)
    {
        var value = await _specialOfferService.GetByIdSpecialOfferAsync(id);
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);

        return StatusCode(201, "SpecialOffer created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);

        return Ok("SpecialOffer updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSpecialOffer(string id)
    {
        await _specialOfferService.DeleteSpecialOfferAsync(id);

        return Ok("SpecialOffer deleted successfully.");
    }
}