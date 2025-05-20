using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.BusinessLayer.Concrete;

public class CargoOperationService(ICargoOperationRepository _repository) : ICargoOperaitonService
{
    public async Task CreateAsync(CreateCargoOperationDto createCargoOperationDto)
    {
        await _repository.CreateAsync(new CargoOperation
        {
            Barcode = createCargoOperationDto.Barcode,
            Description = createCargoOperationDto.Description,
            OpeartionDate = createCargoOperationDto.OpeartionDate,
        });

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);

        _repository.Delete(value);

        await _repository.SaveChangesAsync();
    }

    public async Task<List<ResultCargoOperationDto>> GetAllAsync()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new ResultCargoOperationDto
        {
            Barcode = x.Barcode,
            Description = x.Description,
            OpeartionDate = x.OpeartionDate,
            CargoOperationId = x.CargoOperationId,
        }).ToList();
    }

    public async Task<GetByIdCargoOperationDto> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);

        return new GetByIdCargoOperationDto
        {
            Barcode = value.Barcode,
            Description = value.Description,
            OpeartionDate = value.OpeartionDate,
            CargoOperationId = value.CargoOperationId,
        };
    }

    public async Task UpdateAsync(UpdateCargoOperationDto updateCargoOperationDto)
    {
        var value = await _repository.GetByIdAsync(updateCargoOperationDto.CargoOperationId);

        value.Barcode = updateCargoOperationDto.Barcode;
        value.Description = updateCargoOperationDto.Description;
        value.OpeartionDate = updateCargoOperationDto.OpeartionDate;

        await _repository.SaveChangesAsync();
    }
}
