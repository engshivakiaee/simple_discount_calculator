public class BasketService : IBasketService
{
    private readonly IList<CartItem> _cartItems = new List<CartItem>();
    public void AddItem(Product product, int quantity = 1)
    {
        var cartItem = _cartItems.FirstOrDefault(x => x.Product.Id == product.Id);
        if (cartItem == null)
        {
            _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
        }
        else
        {
            cartItem.Quantity += quantity;
        }
    }

    public void RemoveFromCart(int productId)
    {
        var cartItem = _cartItems.FirstOrDefault(x => x.Product.Id == productId);
        if (cartItem != null)
        {
            _cartItems.Remove(cartItem);
        }
    }

    public decimal CalculateCartTotalIncludingDiscount()
    {
        decimal total = 0;
        foreach (var cartItem in _cartItems)
        {
            var discount = cartItem.Product.Discount;

            if (discount != null && (discount?.ValidUntil ?? DateTime.MaxValue) >= DateTime.Now)
            {
                total += discount?.DiscountType switch {
                    DiscountType.Amount => (cartItem.Product.Price - discount.DiscountAmount) * cartItem.Quantity,
                    DiscountType.Percentage => (cartItem.Product.Price - (cartItem.Product.Price * (discount.DiscountAmount / 100))) * cartItem.Quantity,
                    DiscountType.TwoForOne => (cartItem.Product.Price * (cartItem.Quantity / 2)) + (cartItem.Product.Price * (cartItem.Quantity % 2)),
                    _ => 0  
                };
            } 
            else 
            {
                total += cartItem.Product.Price * cartItem.Quantity;
            }
        }
        return total;
    }
}