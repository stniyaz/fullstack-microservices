using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoDetailsController(ICargoDetailService _cargoDetailService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCargDetails()
    {
        var values = await _cargoDetailService.GetAllAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoDetailById(int id)
    {
        var value = await _cargoDetailService.GetByIdAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
    {
        await _cargoDetailService.CreateAsync(createCargoDetailDto);

        return StatusCode(201, "CargoDetail created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
    {
        await _cargoDetailService.UpdateAsync(updateCargoDetailDto);

        return Ok("CargoDetail updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoDetail(int id)
    {
        await _cargoDetailService.DeleteAsync(id);

        return Ok("CargoDetail deleted successfully.");
    }
}
