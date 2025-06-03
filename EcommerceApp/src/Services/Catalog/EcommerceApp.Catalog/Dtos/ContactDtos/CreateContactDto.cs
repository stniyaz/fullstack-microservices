namespace EcommerceApp.Catalog.Dtos.ContactDtos;

public class CreateContactDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsSeen { get; set; } = false;
    public DateTime SendDate { get; set; } = DateTime.UtcNow.AddHours(4);
}
