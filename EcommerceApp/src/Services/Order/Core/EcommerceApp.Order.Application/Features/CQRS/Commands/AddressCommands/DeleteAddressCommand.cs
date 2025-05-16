namespace EcommerceApp.Order.Application.Features.CQRS.Commands.AddressCommands;

public class DeleteAddressCommand
{
    public int AddressId { get; set; }

    public DeleteAddressCommand(int addressId)
    {
        AddressId = addressId;
    }
}
