using Core;

namespace Shop.Dal;

public class ClientDaoFileRepository : IRepository<ClientDao>
{
    private const string FileName = "clients.txt";

    public void Create(ClientDao item)
    {
        using var writer = new StreamWriter(FileName, append: true);
        writer.WriteLine($"{item.Id},{item.Name},{item.Surname},{item.Patronymic},{item.BirthDay:O}");
    }

    public ClientDao? Read(int id) => ReadAll().Find(x => x.Id == id);

    public List<ClientDao> ReadAll()
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

    public void Update(ClientDao item)
    {
        var items = ReadAll();
        int index = items.FindIndex(x => x.Id == item.Id);
        if (index >= 0) items[index] = item;
        Save(items);
    }

    public void Delete(int id)
    {
        var items = ReadAll();
        items.RemoveAll(x => x.Id == id);
        Save(items);
    }

    private static void Save(List<ClientDao> items) =>
        File.WriteAllLines(FileName, items.Select(x => $"{x.Id},{x.Name},{x.Surname},{x.Patronymic},{x.BirthDay:O}"));
}
