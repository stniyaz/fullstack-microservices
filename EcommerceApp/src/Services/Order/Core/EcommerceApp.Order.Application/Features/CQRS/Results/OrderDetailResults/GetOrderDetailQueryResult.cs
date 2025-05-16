namespace EcommerceApp.Order.Application.Features.CQRS.Results.OrderDetailResults;

public class GetOrderDetailQueryResult
{
    public int OderDetailId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int OrderingId { get; set; }
}
