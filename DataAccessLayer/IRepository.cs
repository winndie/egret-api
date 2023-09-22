namespace EgretApi.DataAccessLayer
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IList<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}