using Core;
using System.Text.Json;

namespace Shop.Dal;

public class ShopDaoJsonRepository : IRepository<ShopDao>
{
    private const string FileName = "shops.json";
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public void Create(ShopDao item)
    {
        ShopDao items = ReadAll();
        items.Add(item);
        Save(items);
    }

    public ShopDao? Read(int id) => ReadAll().Find(x => x.Id == id);

    public List<ShopDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<ShopDao>();

        return JsonSerializer.Deserialize<List<ShopDao>>(File.ReadAllText(FileName), Options)
               ?? new List<ShopDao>();
    }

    public void Update(ShopDao item)
    {
        ShopDao items = ReadAll();
        int index = items.FindIndex(x => x.Id == item.Id);
        if (index >= 0)
        {
            items[index] = item;
            Save(items);
        }
    }

    public void Delete(int id)
    {
        var items = ReadAll();
        items.RemoveAll(x => x.Id == id);
        Save(items);
    }

    private static void Save(List<ShopDao> items) =>
        File.WriteAllText(FileName, JsonSerializer.Serialize(items, Options));
}
