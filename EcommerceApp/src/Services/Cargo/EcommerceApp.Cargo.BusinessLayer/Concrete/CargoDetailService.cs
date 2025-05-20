using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.BusinessLayer.Concrete;

public class CargoDetailService(ICargoDetailRepository _repository) : ICargoDetailService
{
    public async Task CreateAsync(CreateCargoDetailDto createCargoDetailDto)
    {
        await _repository.CreateAsync(new CargoDetail
        {
            SenderCustomer = createCargoDetailDto.SenderCustomer,
            ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
            Barcode = createCargoDetailDto.Barcode,
            CargoCompanyId = createCargoDetailDto.CargoCompanyId
        });

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);

        _repository.Delete(value);

        await _repository.SaveChangesAsync();
    }

    public async Task<List<ResultCargoDetailDto>> GetAllAsync()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new ResultCargoDetailDto
        {
            SenderCustomer = x.SenderCustomer,
            ReceiverCustomer = x.ReceiverCustomer,
            Barcode = x.Barcode,
            CargoCompanyId = x.CargoCompanyId,
            CargoDetailId = x.CargoDetailId
        }).ToList();
    }

    public async Task<GetByIdCargoDetailDto> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);

        return new GetByIdCargoDetailDto
        {
            SenderCustomer = value.SenderCustomer,
            ReceiverCustomer = value.ReceiverCustomer,
            Barcode = value.Barcode,
            CargoCompanyId = value.CargoCompanyId,
            CargoDetailId = value.CargoDetailId
        };
    }

    public async Task UpdateAsync(UpdateCargoDetailDto updateCargoDetailDto)
    {
        var value = await _repository.GetByIdAsync(updateCargoDetailDto.CargoDetailId);

        value.SenderCustomer = updateCargoDetailDto.SenderCustomer;
        value.ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer;
        value.Barcode = updateCargoDetailDto.Barcode;
        value.CargoCompanyId = updateCargoDetailDto.CargoCompanyId;

        await _repository.SaveChangesAsync();
    }
}
