namespace PayrollAndHr.Server.Repo
{
    public interface IGenericRepo<T> where T : class
    {
        void Delete(T entity);
        T? GetById(int id);
        T? GetByValue(T value);
        void Save(T entity);
    }
}