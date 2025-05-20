using EcommerceApp.Cargo.BusinessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.BusinessLayer.Concrete;

public class CargoCustomerService(ICargoCustomerRepository _repository) : ICargoCustomerService
{
    public async Task CreateAsync(CreateCargoCustomerDto createCargoCustomerDto)
    {
        await _repository.CreateAsync(new CargoCustomer
        {
            Name = createCargoCustomerDto.Name,
            Surname = createCargoCustomerDto.Surname,
            Email = createCargoCustomerDto.Email,
            Phone = createCargoCustomerDto.Phone,
            City = createCargoCustomerDto.City,
            District = createCargoCustomerDto.District,
            Address = createCargoCustomerDto.Address,
            UserCustomerId = createCargoCustomerDto.UserCustomerId,
        });

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);
        _repository.Delete(value);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<ResultCargoCustomerDto>> GetAllAsync()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new ResultCargoCustomerDto
        {
            CargoCustomerId = x.CargoCustomerId,
            Name = x.Name,
            Surname = x.Surname,
            Email = x.Email,
            Phone = x.Phone,
            City = x.City,
            District = x.District,
            Address = x.Address,
            UserCustomerId = x.UserCustomerId
        }).ToList();
    }

    public async Task<GetByIdCargoCustomerDto> GetByIdAsync(int id)
    {
        var value = await _repository.GetByIdAsync(id);

        return new GetByIdCargoCustomerDto
        {
            CargoCustomerId = value.CargoCustomerId,
            Name = value.Name,
            Surname = value.Surname,
            Email = value.Email,
            Phone = value.Phone,
            City = value.City,
            District = value.District,
            Address = value.Address,
            UserCustomerId = value.UserCustomerId
        };
    }

    public async Task UpdateAsync(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        var value = await _repository.GetByIdAsync(updateCargoCustomerDto.CargoCustomerId);

        value.Name = updateCargoCustomerDto.Name;
        value.Surname = updateCargoCustomerDto.Surname;
        value.Email = updateCargoCustomerDto.Email;
        value.Phone = updateCargoCustomerDto.Phone;
        value.City = updateCargoCustomerDto.City;
        value.District = updateCargoCustomerDto.District;
        value.Address = updateCargoCustomerDto.Address;
        value.UserCustomerId = updateCargoCustomerDto.UserCustomerId;

        await _repository.SaveChangesAsync();
    }
}
