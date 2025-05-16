using System.Reflection.Metadata.Ecma335;

namespace EcommerceApp.Order.Domain.Entities;

public class OrderDetail
{
    public int OderDetailId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int OrderingId { get; set; }

    public Ordering Ordering { get; set; }
}
