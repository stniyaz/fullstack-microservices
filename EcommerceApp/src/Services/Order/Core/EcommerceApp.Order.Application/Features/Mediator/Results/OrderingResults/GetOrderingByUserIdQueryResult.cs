using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.Mediator.Results.OrderingResults;

public class GetOrderingByUserIdQueryResult
{
    public int OrderingId { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}
