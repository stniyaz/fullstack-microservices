using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Concrete;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.DataAccessLayer.Repositories;

public class CargoCustomerRepository : GenericRepository<CargoCustomer>, ICargoCustomerRepository
{
    public CargoCustomerRepository(CargoContext _context) : base(_context) { }
}
