namespace EcommerceApp.WebUI.Areas.Manage.ViewModels;

public class DashboardViewModel
{
    public long CategoryCount { get; set; }
    public long ProductCount { get; set; }
    public long BrandCount { get; set; }
    public decimal ProductAvgPrice { get; set; }
    public string MaxPriceProductName { get; set; }
    public string MinPriceProductName { get; set; }

    public int ActiveUserCommentCount { get; set; }
    public int PassiveUserCommentCount { get; set; }
    public int TotalUserCommentCount { get; set; }

    public int CouponCount { get; set; }

    public int TotalUserMessageCount { get; set; }

    public int UserCount { get; set; }
}
