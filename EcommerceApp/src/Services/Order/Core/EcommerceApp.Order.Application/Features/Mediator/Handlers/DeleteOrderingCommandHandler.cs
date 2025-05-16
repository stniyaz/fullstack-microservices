using EcommerceApp.Order.Application.Features.Mediator.Commands.OrderingCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;
using MediatR;

namespace EcommerceApp.Order.Application.Features.Mediator.Handlers;

public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
{
    private readonly IGenericRepository<Ordering> _repository;

    public DeleteOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);

        if (value is not null)
        {
            await _repository.DeleteAsync(value);
        }
    }
}
