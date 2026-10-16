using Core;
using Microsoft.EntityFrameworkCore;

namespace Shop.Dal;
public class DatabaseRepositoryBase<T> : IRepository<T>
    where T : class, IPrimary
{
    private readonly ShopEntityContext _context;
    private readonly DbSet<T> _table;

    public DatabaseRepositoryBase(
        ShopEntityContext context,
        DbSet<T> table)
    {
        _context = context;
        _table = table;
    }

    public void Create(T item)
    {
        var existingItem = _table.Find(item.Id);

        if (existingItem != null)
        {
            return;
        }

        _table.Add(item);
        _context.SaveChanges();
    }

    public T? Read(int id)
    {
        return _table.Find(id);
    }

    public List<T> ReadAll()
    {
        return _table.ToList();
    }

    public void Update(T item)
    {
        var existingItem = _table.Find(item.Id);
        if ( existingItem != null)
        {
            _context.Entry(existingItem).CurrentValues.SetValues(item);
            _context.SaveChanges(true);
        }
    }

    public void Delete(int id)
    {
        var item = _table.Find(id);

        if (item != null)
        {
            _table.Remove(item);
            _context.SaveChanges();
        }
    }
}