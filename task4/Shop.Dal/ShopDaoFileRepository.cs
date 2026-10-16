using Core;

namespace Shop.Dal;

public class ShopDaoFileRepository : RepositoryBase<ShopDao>
{
    private const string FileName = "shops.txt";

    public override List<ShopDao> ReadAll()
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
    protected override void Save(List<ShopDao> items) =>
        File.WriteAllLines(FileName, items.Select(x => $"{x.Id},{x.Name},{x.Code}"));
}
