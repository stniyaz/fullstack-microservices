using EcommerceApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var value = await _repository.GetByIdAsync(command.OderDetailId);

        if (value != null)
        {
            value.ProductPrice = command.ProductPrice;
            value.ProductName = command.ProductName;
            value.ProductId = command.ProductId;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.OrderingId = command.OrderingId;
            value.ProductCount = command.ProductCount;

            await _repository.UpdateAsync(value);
        }
    }
}
