using System;
using System.Collections.Generic;

namespace task3
{
    public interface IRepository<T>
    {
        void Create(T item);
        T Read(int id);
        List<T> ReadAll();
        void Update(T item);
        void Delete(int id);
    }
}