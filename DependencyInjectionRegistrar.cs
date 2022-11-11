
namespace villa_plus_test
{
    public static class DependencyInjectionRegistrar
    {
        public static ServiceProvider Register()
        {
            return new ServiceCollection()
           .AddScoped<IBasketService, BasketService>()
           .BuildServiceProvider();
        }
    }
}
