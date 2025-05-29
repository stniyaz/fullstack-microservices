namespace EcommerceApp.DtoLayer.CommentDtos.UserCommentDtos;

public class CreateUserCommentDto
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string CommentDetail { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow.AddHours(4);
    public bool Status { get; set; } = true;
    public string ProductId { get; set; }
}
