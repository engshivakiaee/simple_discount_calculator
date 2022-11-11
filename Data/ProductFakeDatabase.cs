public static class ProductFakeDatabase
{
    public static IList<Product> GetProducts()
    {
        // Fake products
        return new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10, Discount = new Discount { DiscountType = DiscountType.Amount, DiscountAmount = 1, ValidUntil = DateTime.Now.AddDays(2) } },
            new Product { Id = 2, Name = "Product 2", Price = 20, Discount = new Discount { DiscountType = DiscountType.Percentage, DiscountAmount = 5, ValidUntil = DateTime.Now.AddDays(2) } },
            new Product { Id = 3, Name = "Product 3", Price = 30, Discount = new Discount { DiscountType = DiscountType.TwoForOne, ValidUntil = DateTime.Now.AddDays(3) } },
            new Product { Id = 4, Name = "Product 4", Price = 40 },
            new Product { Id = 5, Name = "Product 5", Price = 50 },
            new Product { Id = 6, Name = "Product 6", Price = 60 },
            new Product { Id = 7, Name = "Product 7", Price = 70 },
            new Product { Id = 8, Name = "Product 8", Price = 80 },
            new Product { Id = 9, Name = "Product 9", Price = 90 },
            new Product { Id = 10, Name = "Product 10", Price = 100 }
        };
    }
}