using ClientBaseControlWebApp.Models;

namespace ClientBaseControlWebApp.Data.Services
{
	public interface IClientsService
	{
		public Task<IEnumerable<Client>> GetAllAsync();
		public Task<IEnumerable<Client>> GetBySearchValue(string searchValue);
		public Task<Client> GetByIdAsync(int id);
		public Task AddAsync(Client client);
		public Task<Client> UpdateAsync(int id, Client newClient);
		public Task DeleteAsync(int id);
	}
}
