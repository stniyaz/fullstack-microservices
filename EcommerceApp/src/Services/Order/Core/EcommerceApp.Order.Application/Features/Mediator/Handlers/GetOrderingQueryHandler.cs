using EcommerceApp.Order.Application.Features.Mediator.Queries.OrderingQueries;
using EcommerceApp.Order.Application.Features.Mediator.Results.OrderingResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;
using MediatR;

namespace EcommerceApp.Order.Application.Features.Mediator.Handlers;

public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IGenericRepository<Ordering> _genericRepository;

    public GetOrderingQueryHandler(IGenericRepository<Ordering> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var value = await _genericRepository.GetAllAsync();

        return value.Select(x => new GetOrderingQueryResult
        {
            OrderingId = x.OrderingId,
            OrderDate = x.OrderDate,
            UserId = x.UserId,
            TotalPrice = x.TotalPrice,
        }).ToList();
    }
}
