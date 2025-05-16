using EcommerceApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IGenericRepository<Address> _repository;
    public CreateAddressCommandHandler(IGenericRepository<Address> _repository)
    {
        this._repository = _repository;
    }

    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _repository.CreateAsync(new Address
        {
            UserId = createAddressCommand.UserId,
            City = createAddressCommand.City,
            District = createAddressCommand.District,
            Detail = createAddressCommand.Detail,
        });
    }
}
