using Core;

namespace Shop.Dal;

public class GoodDaoFileRepository : IRepository<GoodDao>
{
    private const string FileName = "goods.txt";

    public void Create(GoodDao item)
    {
        using var writer = new StreamWriter(FileName, append: true);
        writer.WriteLine($"{item.Id},{item.Name},{item.Code}");
    }

    public GoodDao? Read(int id) => ReadAll().Find(x => x.Id == id);

    public List<GoodDao> ReadAll()
    {
        var result = new List<GoodDao>();
        if (!File.Exists(FileName)) return result;

        foreach (var line in File.ReadLines(FileName))
        {
            var data = line.Split(',');
            if (data.Length >= 3)
                result.Add(new GoodDao { Id = int.Parse(data[0]), Name = data[1], Code = int.Parse(data[2]) });
        }
        return result;
    }

    public void Update(GoodDao item)
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

    private static void Save(List<GoodDao> items) =>
        File.WriteAllLines(FileName, items.Select(x => $"{x.Id},{x.Name},{x.Code}"));
}
