public class Discount
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal DiscountAmount { get; set; }
    public DiscountType DiscountType { get; set; }
    public DateTime? ValidUntil { get; set; }
}

public enum DiscountType
{
    Amount,
    Percentage,
    TwoForOne
}