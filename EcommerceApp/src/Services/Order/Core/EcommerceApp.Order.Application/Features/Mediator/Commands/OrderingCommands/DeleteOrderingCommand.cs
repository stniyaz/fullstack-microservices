using MediatR;

namespace EcommerceApp.Order.Application.Features.Mediator.Commands.OrderingCommands;

public class DeleteOrderingCommand : IRequest
{
    public int Id { get; set; }

    public DeleteOrderingCommand(int id)
    {
        this.Id = id;
    }
}
