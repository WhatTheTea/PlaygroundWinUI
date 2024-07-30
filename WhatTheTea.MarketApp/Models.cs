using System.Collections.Generic;

namespace WhatTheTea.MarketApp.Models
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required double Price { get; set; }
    }
    public class Seller
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required double Rating { get; set; }
        public required IEnumerable<Product> Products { get; set; }
    }
}
