namespace EcommerceApp.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

public class GetOrderDetailByIdQuery
{
    public int OrderDetailId { get; set; }

    public GetOrderDetailByIdQuery(int orderDetailId)
    {
        OrderDetailId = orderDetailId;
    }
}
