using Core;
using System.Text.Json;

namespace Shop.Dal;

public class GoodDaoJsonRepository : IRepository<GoodDao>
{
    private const string FileName = "goods.json";
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public void Create(GoodDao item)
    {
        var items = ReadAll();
        items.Add(item);
        Save(items);
    }

    public GoodDao? Read(int id) => ReadAll().Find(x => x.Id == id);

    public List<GoodDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<GoodDao>();

        return JsonSerializer.Deserialize<List<GoodDao>>(File.ReadAllText(FileName), Options)
               ?? new List<GoodDao>();
    }

    public void Update(GoodDao item)
    {
        var items = ReadAll();
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

    private static void Save(List<GoodDao> items) =>
        File.WriteAllText(FileName, JsonSerializer.Serialize(items, Options));
}
