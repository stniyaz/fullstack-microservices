namespace EcommerceApp.Cargo.DtoLayer.Dtos.CargoOperationDtos;

public class GetByIdCargoOperationDto
{
    public int CargoOperationId { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OpeartionDate { get; set; }
}
