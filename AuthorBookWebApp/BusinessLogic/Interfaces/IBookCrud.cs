namespace AuthorBookWebApp.BusinessLogic.Interfaces
{
    public interface IBookCrud<T>
    {
        List<T> GetAll();
        T? GetById(int? id);
        void Add(T model);
        void Delete(int id);
        void Update(int id, T model);
    }
}
