using EcommerceApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IGenericRepository<Address> _repository;

    public UpdateAddressCommandHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAddressCommand updateAddressCommand)
    {
        var value = await _repository.GetByIdAsync(updateAddressCommand.AddressId);

        if (value != null)
        {
            value.UserId = updateAddressCommand.UserId;
            value.Name = updateAddressCommand.Name;
            value.Surname = updateAddressCommand.Surname;
            value.Email = updateAddressCommand.Email;
            value.Number = updateAddressCommand.Number;
            value.Line1 = updateAddressCommand.Line1;
            value.Line2 = updateAddressCommand.Line2;
            value.Country = updateAddressCommand.Country;
            value.City = updateAddressCommand.City;
            value.ZipCode = updateAddressCommand.ZipCode;

            await _repository.UpdateAsync(value);
        }
    }
}
