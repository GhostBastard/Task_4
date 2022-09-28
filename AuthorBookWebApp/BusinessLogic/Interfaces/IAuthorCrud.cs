using AuthorBookWebApp.Models;

namespace AuthorBookWebApp.BusinessLogic.Interfaces
{
    public interface IAuthorCrud<T>
    {

        List<T> GetAll();
        T? GetById(int? id);
        void Add(T model);
        void Delete(int id);
        void Update(int id, T model);
        AuthorViewModel? GetByIdWithoutTracking(int? id);
        List<AuthorViewModel> GetAllWithoutTracking();
    }
}
