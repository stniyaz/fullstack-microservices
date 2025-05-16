using EcommerceApp.Order.Application.Features.Mediator.Commands.OrderingCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;
using MediatR;

namespace EcommerceApp.Order.Application.Features.Mediator.Handlers;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IGenericRepository<Ordering> _repository;
    public CreateOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Ordering
        {
            OrderDate = request.OrderDate,
            TotalPrice = request.TotalPrice,
            UserId = request.UserId,
        });
    }
}
