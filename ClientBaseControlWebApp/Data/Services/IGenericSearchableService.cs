using ClientBaseControlWebApp.Models;

namespace ClientBaseControlWebApp.Data.Services
{
    public interface IGenericSearchableService<T>
    {
        Task<IEnumerable<T>> GetBySearchValue(string searchValue);
    }
}
