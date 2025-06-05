using EcommerceApp.Order.Application.Features.Mediator.Queries.OrderingQueries;
using EcommerceApp.Order.Application.Features.Mediator.Results.OrderingResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;
using MediatR;

namespace EcommerceApp.Order.Application.Features.Mediator.Handlers;

public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
{
    private readonly IGenericRepository<Ordering> _genericRepository;
    public GetOrderingByUserIdQueryHandler(IGenericRepository<Ordering> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _genericRepository.GetAllWhereAsync(x => x.UserId == request.UserId);

        return values.Select(x => new GetOrderingByUserIdQueryResult
        {
            OrderingId = x.OrderingId,
            OrderDate = x.OrderDate,
            UserId = x.UserId,
            TotalPrice = x.TotalPrice,
        }).ToList();
    }
}
