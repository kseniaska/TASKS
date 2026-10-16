using Core;
using System.Text.Json;

namespace Shop.Dal;

public class ShopDaoJsonRepository : RepositoryBase<ShopDao>
{
    private const string FileName = "shops.json";
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };


    public override List<ShopDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<ShopDao>();

        return JsonSerializer.Deserialize<List<ShopDao>>(File.ReadAllText(FileName), Options)
               ?? new List<ShopDao>();
    }
    protected override void Save(List<ShopDao> items) =>
        File.WriteAllText(FileName, JsonSerializer.Serialize(items, Options));
}
