using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Concrete;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.DataAccessLayer.Repositories;

public class CargoCompanyRepository : GenericRepository<CargoCompany>, ICargoCompanyRepository
{
    public CargoCompanyRepository(CargoContext _context) : base(_context) { }
}
