using System.Collections.Generic;

namespace Assignment2.Repositories
{
    public interface IRepository<T> where T : class
    {

        T Get(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);


    }
}
