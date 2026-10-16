using Core;
using System.Text.Json;

namespace Shop.Dal;

public class ClientDaoJsonRepository : IRepository<ClientDao>
{
    private const string FileName = "clients.json";
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public void Create(ClientDao item)
    {
        var items = ReadAll();
        items.Add(item);
        Save(items);
    }

    public ClientDao? Read(int id) => ReadAll().Find(x => x.Id == id);

    public List<ClientDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<ClientDao>();

        return JsonSerializer.Deserialize<List<ClientDao>>(File.ReadAllText(FileName), Options)
               ?? new List<ClientDao>();
    }

    public void Update(ClientDao item)
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

    private static void Save(List<ClientDao> items) =>
        File.WriteAllText(FileName, JsonSerializer.Serialize(items, Options));
}
