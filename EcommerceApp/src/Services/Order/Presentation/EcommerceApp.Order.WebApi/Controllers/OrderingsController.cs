using EcommerceApp.Order.Application.Features.Mediator.Commands.OrderingCommands;
using EcommerceApp.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderingsController(IMediator _mediator) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllOrderings()
    {
        var values = await _mediator.Send(new GetOrderingQuery());

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        var value = await _mediator.Send(new GetOrderingByIdQuery(id));

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
    {
        await _mediator.Send(command);

        return StatusCode(201, "Ordering created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
    {
        await _mediator.Send(command);

        return Ok("Ordering updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrdering(int id)
    {
        await _mediator.Send(new DeleteOrderingCommand(id));

        return Ok("Ordering deleted successfully.");
    }
}
