using Core;

namespace Shop.Dal;

public class GoodDaoFileRepository : RepositoryBase<GoodDao>
{
    private const string FileName = "goods.txt";

    public override List<GoodDao> ReadAll()
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

    protected override void Save(List<GoodDao> items) =>
        File.WriteAllLines(FileName, items.Select(x => $"{x.Id},{x.Name},{x.Code}"));
}
