using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.BusinessLayer.Concrete;

public class CargoCompanyService(ICargoCompanyRepository _repository) : ICargoCompanyService
{
    public async Task CreateAsync(CreateCargoCompanyDto createCargoCompanyDto)
    {
        await _repository.CreateAsync(new CargoCompany
        {
            CargoCompanyName = createCargoCompanyDto.CompanyName,
        });
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        _repository.Delete(value);

        await _repository.SaveChangesAsync();
    }

    public async Task<List<ResultCargoCompanyDto>> GetAllAsync()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new ResultCargoCompanyDto
        {
            CargoCompanyId = x.CargoCompanyId,
            CompanyName = x.CargoCompanyName,
        }).ToList();
    }

    public async Task<GetByIdCargoCompanyDto> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);

        return new GetByIdCargoCompanyDto
        {
            CompanyName = value.CargoCompanyName,
            CargoCompanyId = value.CargoCompanyId,
        };
    }

    public async Task UpdateAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        var value = await _repository.GetByIdAsync(updateCargoCompanyDto.CargoCompanyId);

        value.CargoCompanyName = updateCargoCompanyDto.CompanyName;

        await _repository.SaveChangesAsync();
    }
}
