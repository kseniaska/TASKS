using Core;
using System.Xml.Serialization;

namespace Shop.Dal;

public class GoodDaoXmlRepository : IRepository<GoodDao>
{
    private const string FileName = "goods.xml";

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

        var serializer = new XmlSerializer(typeof(List<GoodDao>));
        using var stream = File.OpenRead(FileName);
        return (List<GoodDao>?)serializer.Deserialize(stream) ?? new List<GoodDao>();
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

    private static void Save(List<GoodDao> items)
    {
        var serializer = new XmlSerializer(typeof(List<GoodDao>));
        using var stream = File.Create(FileName);
        serializer.Serialize(stream, items);
    }
}
