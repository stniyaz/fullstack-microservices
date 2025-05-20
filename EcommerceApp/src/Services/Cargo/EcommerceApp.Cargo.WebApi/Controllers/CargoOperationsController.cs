using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoOperationsController(ICargoOperaitonService _cargoOperaitonService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCargoOperations()
    {
        var values = await _cargoOperaitonService.GetAllAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoOperationById(int id)
    {
        var value = await _cargoOperaitonService.GetByIdAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
    {
        await _cargoOperaitonService.CreateAsync(createCargoOperationDto);

        return StatusCode(201, "CargoOperation created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
    {
        await _cargoOperaitonService.UpdateAsync(updateCargoOperationDto);

        return Ok("CargoOperation updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoOperation(int id)
    {
        await _cargoOperaitonService.DeleteAsync(id);

        return Ok("CargoOperation deleted successfully.");
    }
}
