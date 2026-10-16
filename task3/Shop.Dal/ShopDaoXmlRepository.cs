using Core;
using System.Xml.Serialization;

namespace Shop.Dal;

public class ShopDaoXmlRepository : IRepository<ShopDao>
{
    private const string FileName = "shops.xml";

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

        XmlSerializer serializer = new XmlSerializer(typeof(List<ShopDao>));
        using var stream = File.OpenRead(FileName);
        return (List<ShopDao>?)serializer.Deserialize(stream) ?? new List<ShopDao>();
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

    private static void Save(List<ShopDao> items)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<ShopDao>));
        using var stream = File.Create(FileName);
        serializer.Serialize(stream, items);
    }
}
