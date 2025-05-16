namespace EcommerceApp.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

public class DeleteOrderDetailCommand
{
    public int OrderDetailId { get; set; }

    public DeleteOrderDetailCommand(int orderDetailId)
    {
        OrderDetailId = orderDetailId;
    }
}
