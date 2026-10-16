using Core;
using System.Xml.Serialization;

namespace Shop.Dal;

public class ClientDaoXmlRepository : IRepository<ClientDao>
{
    private const string FileName = "clients.xml";

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

        var serializer = new XmlSerializer(typeof(List<ClientDao>));
        using var stream = File.OpenRead(FileName);
        return (List<ClientDao>?)serializer.Deserialize(stream) ?? new List<ClientDao>();
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

    private static void Save(List<ClientDao> items)
    {
        var serializer = new XmlSerializer(typeof(List<ClientDao>));
        using var stream = File.Create(FileName);
        serializer.Serialize(stream, items);
    }
}
