using Core;

namespace Shop.Dal;

public class ClientDaoFileRepository : RepositoryBase<ClientDao>
{
    private const string FileName = "clients.txt";

    public override List<ClientDao> ReadAll()
    {
        var result = new List<ClientDao>();
        if (!File.Exists(FileName)) return result;

        foreach (var line in File.ReadLines(FileName))
        {
            var data = line.Split(',');
            if (data.Length >= 5)
                result.Add(new ClientDao
                {
                    Id = int.Parse(data[0]),
                    Name = data[1],
                    Surname = data[2],
                    Patronymic = data[3],
                    BirthDay = DateTime.Parse(data[4])
                });
        }
        return result;
    }

    protected override void Save(List<ClientDao> items) =>
        File.WriteAllLines(FileName, items.Select(x => $"{x.Id},{x.Name},{x.Surname},{x.Patronymic},{x.BirthDay:O}"));
}
