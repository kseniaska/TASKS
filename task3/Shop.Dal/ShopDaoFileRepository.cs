using Core;

namespace Shop.Dal;

public class ShopDaoFileRepository : IRepository<ShopDao>
{
    private const string FileName = "shops.txt";

    public void Create(ShopDao item)
    {
        using var writer = new StreamWriter(FileName, append: true);
        writer.WriteLine($"{item.Id},{item.Name},{item.Code}");
    }

    public ShopDao? Read(int id) => ReadAll().Find(x => x.Id == id);

    public List<ShopDao> ReadAll()
    {
        var result = new List<ShopDao>();
        if (!File.Exists(FileName)) return result;

        foreach (var line in File.ReadLines(FileName))
        {
            var data = line.Split(',');
            if (data.Length >= 3)
                result.Add(new ShopDao { Id = int.Parse(data[0]), Name = data[1], Code = int.Parse(data[2]) });
        }
        return result;
    }

    public void Update(ShopDao item)
    {
        var items = ReadAll();
        int index = items.FindIndex(x => x.Id == item.Id);
        if (index >= 0) items[index] = item;
        Save(items);
    }

    public void Delete(int id)
    {
        var items = ReadAll();
        items.RemoveAll(x => x.Id == id);
        Save(items);
    }

    private static void Save(List<ShopDao> items) =>
        File.WriteAllLines(FileName, items.Select(x => $"{x.Id},{x.Name},{x.Code}"));
}
