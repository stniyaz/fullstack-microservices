using EcommerceApp.Cargo.DataAccessLayer.Abstract;
using EcommerceApp.Cargo.DataAccessLayer.Concrete;
using EcommerceApp.Cargo.EntityLayer.Concrete;

namespace EcommerceApp.Cargo.DataAccessLayer.Repositories;

public class CargoOperationRepository : GenericRepository<CargoOperation>, ICargoOperationRepository
{
    public CargoOperationRepository(CargoContext _context) : base(_context) { }
}
