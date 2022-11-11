namespace villa_plus_test.Services
{
    public interface IBasketService
    {
        void AddItem(Product product, int quantity = 1);
        void RemoveFromCart(int productId);
        decimal CalculateCartTotalIncludingDiscount();
    }
}
