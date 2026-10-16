using Core;
using System.Xml.Serialization;

namespace Shop.Dal;

public class ShopDaoXmlRepository : RepositoryBase<ShopDao>
{
    private const string FileName = "shops.xml";

    public override List<ShopDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<ShopDao>();

        XmlSerializer serializer = new XmlSerializer(typeof(List<ShopDao>));
        using var stream = File.OpenRead(FileName);
        return (List<ShopDao>?)serializer.Deserialize(stream) ?? new List<ShopDao>();
    }

    protected override void Save(List<ShopDao> items)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<ShopDao>));
        using var stream = File.Create(FileName);
        serializer.Serialize(stream, items);
    }
}
