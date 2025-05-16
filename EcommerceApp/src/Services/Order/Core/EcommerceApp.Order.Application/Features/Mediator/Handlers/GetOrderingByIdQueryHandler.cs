using EcommerceApp.Order.Application.Features.Mediator.Queries.OrderingQueries;
using EcommerceApp.Order.Application.Features.Mediator.Results.OrderingResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;
using MediatR;

namespace EcommerceApp.Order.Application.Features.Mediator.Handlers;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IGenericRepository<Ordering> _repository;

    public GetOrderingByIdQueryHandler(IGenericRepository<Ordering> _repository)
    {
        this._repository = _repository;
    }
    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);

        return new GetOrderingByIdQueryResult
        {
            OrderDate = value.OrderDate,
            UserId = value.UserId,
            OrderingId = value.OrderingId,
            TotalPrice = value.TotalPrice,
        };
    }
}
