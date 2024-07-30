namespace WhatTheTea.MarketApp.Models
{
    public record Product(int Id, string Title, string Description, double Price);
    public record Seller(int Id, string Title, string Description, double Rating, Product[] Products);
}
