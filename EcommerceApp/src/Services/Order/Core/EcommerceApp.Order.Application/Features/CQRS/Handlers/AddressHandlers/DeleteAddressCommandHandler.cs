using EcommerceApp.Order.Application.Features.CQRS.Commands.AddressCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;

namespace EcommerceApp.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class DeleteAddressCommandHandler
{
    private readonly IGenericRepository<Address> _repository;

    public DeleteAddressCommandHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteAddressCommand deleteAddressCommand)
    {
        var value = await _repository.GetByIdAsync(deleteAddressCommand.AddressId);

        if(value != null)
        {
            await _repository.DeleteAsync(value);
        }
    }
}
