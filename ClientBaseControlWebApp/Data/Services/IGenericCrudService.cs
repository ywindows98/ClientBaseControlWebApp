using ClientBaseControlWebApp.Models;

namespace ClientBaseControlWebApp.Data.Services
{
    public interface IGenericCrudService<T>
    {
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T item);
        Task<T> UpdateAsync(int id, T newItem);
        Task DeleteAsync(int id);
    }
}
