using EcommerceApp.Order.Application.Features.CQRS.Results.AddressResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;
using System.Threading.Tasks;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    private readonly IGenericRepository<Address> _repository;

    public GetAddressQueryHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetAddressQueryResult
        {
            AddressId = x.AddressId,
            UserId = x.UserId,
            Detail = x.Detail,
            City = x.City,
            District = x.District,
        }).ToList();
    }
}
