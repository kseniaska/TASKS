using Core;
using System.Text.Json;

namespace Shop.Dal;

public class ClientDaoJsonRepository : RepositoryBase<ClientDao>
{
    private const string FileName = "clients.json";
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

    public override List<ClientDao> ReadAll()
    {
        if (!File.Exists(FileName))
            return new List<ClientDao>();

        return JsonSerializer.Deserialize<List<ClientDao>>(File.ReadAllText(FileName), Options)
               ?? new List<ClientDao>();
    }

    protected override void Save(List<ClientDao> items) =>
        File.WriteAllText(FileName, JsonSerializer.Serialize(items, Options));
}
