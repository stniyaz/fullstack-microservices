using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Cargo.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CargoCompaniesController(ICargoCompanyService _cargoCompanyService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllCargoCompanies()
    {
        var values = await _cargoCompanyService.GetAllAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCargoCompanyById(int id)
    {
        var value = await _cargoCompanyService.GetByIdAsync(id);

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
    {
        await _cargoCompanyService.CreateAsync(createCargoCompanyDto);

        return StatusCode(201, "Cargo company created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        await _cargoCompanyService.UpdateAsync(updateCargoCompanyDto);

        return Ok("Cargo company updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCargoCompany(int id)
    {
        await _cargoCompanyService.DeleteAsync(id);

        return Ok("Cargo company deleted successfully.");
    }
}
