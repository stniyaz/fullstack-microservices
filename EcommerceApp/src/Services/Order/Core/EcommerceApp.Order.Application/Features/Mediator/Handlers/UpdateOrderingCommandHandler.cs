using EcommerceApp.Order.Application.Features.Mediator.Commands.OrderingCommands;
using EcommerceApp.Order.Application.Interfaces;
using EcommerceApp.Order.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Order.Application.Features.Mediator.Handlers;

partial class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IGenericRepository<Ordering> _repository;

    public UpdateOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.OrderingId);

        if (value is not null)
        {
            value.OrderDate = request.OrderDate;
            value.UserId = request.UserId;
            value.TotalPrice = request.TotalPrice;

            await _repository.UpdateAsync(value);
        }
    }
}
