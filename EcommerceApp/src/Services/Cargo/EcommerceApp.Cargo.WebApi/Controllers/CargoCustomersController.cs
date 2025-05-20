using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCustomersController(ICargoCustomerService _cargoCustomerService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCargoCustomers()
    {
        var values = await _cargoCustomerService.GetAllAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoCustomerById(int id)
    {
        var value = await _cargoCustomerService.GetByIdAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        await _cargoCustomerService.CreateAsync(createCargoCustomerDto);

        return StatusCode(201, "Cargo customer created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        await _cargoCustomerService.UpdateAsync(updateCargoCustomerDto);

        return Ok("Cargo customer updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoCustomer(int id)
    {
        await _cargoCustomerService.DeleteAsync(id);

        return Ok("Cargo customer deleted successfully.");
    }
}
