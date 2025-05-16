using EcommerceApp.Order.Application.Features.CQRS.Queries.AddressQueries;
using EcommerceApp.Order.Application.Features.CQRS.Results.AddressResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IGenericRepository<Address> _repository;

    public GetAddressByIdQueryHandler(IGenericRepository<Address> repository)
    {
        this._repository = repository;
    }

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
    {
        var value = await _repository.GetByIdAsync(getAddressByIdQuery.Id);

        return new GetAddressByIdQueryResult
        {
            AddressId = value.AddressId,
            City = value.City,
            District = value.District,
            UserId = value.UserId,
            Detail = value.Detail,
        };
    }
}
