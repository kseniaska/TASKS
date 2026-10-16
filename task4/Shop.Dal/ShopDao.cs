using Core;

namespace Shop.Dal;

public class ShopDao : IPrimary
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Code { get; set; }
}
