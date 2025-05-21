﻿namespace EcommerceApp.Basket.Dtos.BasketDtos;

public class BasketTotalDto
{
    public string UserId { get; set; }
    public string DiscountCode { get; set; }
    public int DiscountRate { get; set; }
    public List<BasketItemDto> BasketItems { get; set; }

    public decimal TotatPrice { get => BasketItems.Sum(x => x.Quantity * x.Price); }
}
