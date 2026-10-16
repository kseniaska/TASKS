using Core;
using System.Xml.Serialization;

namespace Shop.Dal;

public class ClientDaoXmlRepository : RepositoryBase<ClientDao>
{
    private const string FileName = "clients.xml";


    public override List<ClientDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<ClientDao>();

        var serializer = new XmlSerializer(typeof(List<ClientDao>));
        using var stream = File.OpenRead(FileName);
        return (List<ClientDao>?)serializer.Deserialize(stream) ?? new List<ClientDao>();
    }

    protected override void Save(List<ClientDao> items)
    {
        var serializer = new XmlSerializer(typeof(List<ClientDao>));
        using var stream = File.Create(FileName);
        serializer.Serialize(stream, items);
    }
}
