using EcommerceApp.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace EcommerceApp.Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
{
    public string UserId { get; set; }
    public GetOrderingByUserIdQuery(string userId)
    {
        UserId = userId;
    }
}
