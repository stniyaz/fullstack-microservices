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
            value.Detail = updateAddressCommand.Detail;
            value.City = updateAddressCommand.City;
            value.District = updateAddressCommand.District;
            value.UserId = updateAddressCommand.UserId;

            await _repository.UpdateAsync(value);
        }
    }
}
