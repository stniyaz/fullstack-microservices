using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Concrete;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.DataAccessLayer.Repositories;

public class CargoDetailRepository : GenericRepository<CargoDetail>, ICargoDetailRepository
{
    public CargoDetailRepository(CargoContext _context) : base(_context) { }
}
