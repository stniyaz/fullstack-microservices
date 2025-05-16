using EcommerceApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class DeleteOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public DeleteOrderDetailCommandHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteOrderDetailCommand command)
    {
        var value = await _repository.GetByIdAsync(command.OrderDetailId);

        if (value != null)
        {
            await _repository.DeleteAsync(value);
        }
    }
}
