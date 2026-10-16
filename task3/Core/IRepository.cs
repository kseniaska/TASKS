namespace Core;

public interface IRepository<T> where T : IPrimary
{
    void Create(T item);
    T? Read(int id);
    List<T> ReadAll();
    void Update(T item);
    void Delete(int id);
}
