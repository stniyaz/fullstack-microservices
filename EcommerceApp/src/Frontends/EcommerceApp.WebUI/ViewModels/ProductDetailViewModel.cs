using EcommerceApp.DtoLayer.CatalogDtos.ProductDtos;
using EcommerceApp.DtoLayer.CommentDtos.UserCommentDtos;

namespace EcommerceApp.WebUI.ViewModels;

public class ProductDetailViewModel
{
    public ResultProductWithCategoryDto Product { get; set; }
    public List<ResultUserCommentDto> Comments { get; set; }
}
