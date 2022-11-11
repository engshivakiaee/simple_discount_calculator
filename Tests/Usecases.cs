namespace villa_plus_test;

public class Usecases
{
    private readonly IBasketService? _basketService;
    public Usecases()
    {
        var serviceProvider = DependencyInjectionRegistrar.Register();
        _basketService = serviceProvider?.GetService<IBasketService>();
    }

    [Fact]
    public void Should_Return_Total_Price()
    {
        // Arrange
        var products = ProductFakeDatabase.GetProducts();

        foreach (var product in products)
        {
            _basketService?.AddItem(product);
        }

        // Act
        var totalPrice = _basketService?.CalculateCartTotalIncludingDiscount();

        // Assert
        Assert.Equal(548, totalPrice);
    }

    [Fact]
    public void Should_Return_Total_Price_With_Discount()
    {
        // Arrange
        _basketService?.AddItem(new Product { Id = 1, Name = "Milk", Price = 20 });
        _basketService?.AddItem(new Product { Id = 2, Name = "Product 2", Price = 30, Discount = new Discount { DiscountType = DiscountType.TwoForOne } }, 2);
        _basketService?.AddItem(new Product { Id = 3, Name = "Product 3", Price = 15 });

        // Act
        var totalPrice = _basketService?.CalculateCartTotalIncludingDiscount();
        Console.WriteLine($"Total: {totalPrice}");

        // Assert
        Assert.Equal(65, totalPrice);
    }

    [Fact]
    public void Should_Return_Total_Price_If_There_Is_Three_Same_Products_With_TwoForOne_Discount()
    {
        // Arrange
        _basketService?.AddItem(new Product { Id = 4, Name = "Orange", Price = 5, Discount = new Discount { DiscountType = DiscountType.TwoForOne } }, 3);

        // Act
        var totalPrice = _basketService?.CalculateCartTotalIncludingDiscount();
        Console.WriteLine($"Total: {totalPrice}");

        // Assert
        Assert.Equal(10, totalPrice);
    }

    [Fact]
    public void Should_Return_Total_Price_Without_Discount()
    {
        // Arrange
        _basketService?.AddItem(new Product { Id = 5, Name = "Limon", Price = 10, Discount = new Discount { DiscountType = DiscountType.Amount, DiscountAmount = 2, ValidUntil = DateTime.Now.AddDays(-1) } }, 5);

        // Act
        var totalPrice = _basketService?.CalculateCartTotalIncludingDiscount();
        Console.WriteLine($"Total: {totalPrice}");

        // Assert
        Assert.Equal(50, totalPrice);
    }
}