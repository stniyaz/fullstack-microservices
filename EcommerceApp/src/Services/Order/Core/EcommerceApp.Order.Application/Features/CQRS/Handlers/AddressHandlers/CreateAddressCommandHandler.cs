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
            Name = createAddressCommand.Name,
            Surname = createAddressCommand.Surname,
            Email = createAddressCommand.Email,
            Number = createAddressCommand.Number,
            Line1 = createAddressCommand.Line1,
            Line2 = createAddressCommand.Line2,
            Country = createAddressCommand.Country,
            City = createAddressCommand.City,
            ZipCode = createAddressCommand.ZipCode,
        });
    }
}
