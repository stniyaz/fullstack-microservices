namespace EcommerceApp.Order.Domain.Entities;

public class Address
{
    public int AddressId { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Number { get; set; }
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
}
