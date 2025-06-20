namespace TODO.Models.Repository
{
    public interface IRepository<T>
    {
        T Find(int Id); 
        void Add(T entity); 
        void Update(int Id,T entity);
        void Delete(int Id, T entity);
        List<T> View(); //select
    }
}
