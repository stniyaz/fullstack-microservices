using EcommerceApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using EcommerceApp.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using EcommerceApp.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Order.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController(GetAddressQueryHandler _getAddressQueryHandler,
                                GetAddressByIdQueryHandler _getAddressByIdQueryHandler,
                                CreateAddressCommandHandler _createAddressCommandHandler,
                                UpdateAddressCommandHandler _updateAddressCommandHandler,
                                DeleteAddressCommandHandler _deleteAddressCommandHandler) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllAddresses()
    {
        var values = await _getAddressQueryHandler.Handle();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
    {
        await _createAddressCommandHandler.Handle(command);

        return StatusCode(201, "Address created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
    {
        await _updateAddressCommandHandler.Handle(command);

        return Ok("Address updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        await _deleteAddressCommandHandler.Handle(new DeleteAddressCommand(id));

        return Ok("Address deleted successfully.");
    }
}
