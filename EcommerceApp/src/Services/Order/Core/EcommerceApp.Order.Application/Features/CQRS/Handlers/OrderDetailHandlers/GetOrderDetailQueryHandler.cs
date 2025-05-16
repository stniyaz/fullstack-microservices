using EcommerceApp.Order.Application.Features.CQRS.Results.OrderDetailResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public GetOrderDetailQueryHandler(IGenericRepository<OrderDetail> repository)
    {
        this._repository = repository;
    }

    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetOrderDetailQueryResult
        {
            ProductCount = x.ProductCount,
            ProductName = x.ProductName,
            ProductId = x.ProductId,
            ProductTotalPrice = x.ProductTotalPrice,
            OrderingId = x.OrderingId,
            OrderDetailId = x.OrderDetailId,
            ProductPrice = x.ProductPrice,
        }).ToList();
    }
}
