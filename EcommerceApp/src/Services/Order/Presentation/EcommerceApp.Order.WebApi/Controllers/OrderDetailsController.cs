using EcommerceApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EcommerceApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using EcommerceApp.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController(GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler,
                                    UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler,
                                    DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler,
                                    CreateOrderDetailCommandHandler _createOrderDetailCommandHandler,
                                    GetOrderDetailQueryHandler _getOrderDetailQueryHandler) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetAllOrderDetails()
    {
        var values = await _getOrderDetailQueryHandler.Handle();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
    {
        await _createOrderDetailCommandHandler.Handle(command);

        return StatusCode(201, "OrderDetail created successfully.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
    {
        await _updateOrderDetailCommandHandler.Handle(command);

        return Ok("OrderDetail updated successfully.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await _deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));

        return Ok("OrderDetail deleted successfully.");
    }
}
