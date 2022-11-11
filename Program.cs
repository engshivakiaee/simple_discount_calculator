using villa_plus_test;

var serviceProvider = DependencyInjectionRegistrar.Register();

var basketService = serviceProvider.GetService<IBasketService>();

var products = ProductFakeDatabase.GetProducts();

foreach (var product in products)
{
    basketService?.AddItem(product);
}

var total = basketService?.CalculateCartTotalIncludingDiscount();
Console.WriteLine($"Total: {total}");
