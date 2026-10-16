using Core;

namespace Shop.Dal;

public class GoodDao : IPrimary
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Code { get; set; }
}
