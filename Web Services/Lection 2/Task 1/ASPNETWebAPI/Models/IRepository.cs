 namespace ASPNETWebAPI.Models
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T Get(int id);

        IQueryable<T> GetAll();

        void Update(int id, T entity);

        T Delete(int id);

        T Delete(T entity);
    }
}