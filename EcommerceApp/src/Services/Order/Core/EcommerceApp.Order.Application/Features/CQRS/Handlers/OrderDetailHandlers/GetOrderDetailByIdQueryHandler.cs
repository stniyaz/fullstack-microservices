using EcommerceApp.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using EcommerceApp.Order.Application.Features.CQRS.Results.OrderDetailResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public GetOrderDetailByIdQueryHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.OrderDetailId);

        return new GetOrderDetailByIdQueryResult
        {
            ProductCount = value.ProductCount,
            ProductName = value.ProductName,
            ProductId = value.ProductId,
            ProductTotalPrice = value.ProductTotalPrice,
            OrderingId = value.OrderingId,
            OrderDetailId = query.OrderDetailId,
            ProductPrice = value.ProductPrice,
        };
    }
}
