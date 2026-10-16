using Core;
using System.Xml.Serialization;

namespace Shop.Dal;

public class GoodDaoXmlRepository : RepositoryBase<GoodDao>
{
    private const string FileName = "goods.xml";

    public override List<GoodDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<GoodDao>();

        var serializer = new XmlSerializer(typeof(List<GoodDao>));
        using var stream = File.OpenRead(FileName);
        return (List<GoodDao>?)serializer.Deserialize(stream) ?? new List<GoodDao>();
    }
    protected override void Save(List<GoodDao> items)
    {
        var serializer = new XmlSerializer(typeof(List<GoodDao>));
        using var stream = File.Create(FileName);
        serializer.Serialize(stream, items);
    }
}
