using System.Collections.Generic;

namespace App.Repos
{
    public abstract class IRepo<T>
    {
        public abstract IEnumerable<T> GetAll();
        public abstract T GetById(int id);
        public abstract void Delete(T obj);
        public abstract void DeleteById(int id);
        public abstract void Update(T obj);
        public abstract T Create(T obj);
        public abstract void SaveChanges();
    }
}
