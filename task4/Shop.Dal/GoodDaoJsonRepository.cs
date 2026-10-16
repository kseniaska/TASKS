using Core;
using System.Text.Json;

namespace Shop.Dal;

public class GoodDaoJsonRepository : RepositoryBase<GoodDao>
{
    private const string FileName = "goods.json";
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };


    public override List<GoodDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<GoodDao>();

        return JsonSerializer.Deserialize<List<GoodDao>>(File.ReadAllText(FileName), Options)
               ?? new List<GoodDao>();
    }

    protected override void Save(List<GoodDao> items) =>
        File.WriteAllText(FileName, JsonSerializer.Serialize(items, Options));
}
