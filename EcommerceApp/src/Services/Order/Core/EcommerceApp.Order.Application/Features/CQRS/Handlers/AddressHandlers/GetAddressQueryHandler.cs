using EcommerceApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using EcommerceApp.Order.Application.Features.CQRS.Results.AddressResults;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

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
            Name = x.Name,
            Surname = x.Surname,
            Email = x.Email,
            Number = x.Number,
            Line1 = x.Line1,
            Line2 = x.Line2,
            Country = x.Country,
            City = x.City,
            ZipCode = x.ZipCode,
        }).ToList();
    }
}
