using ClientBaseControlWebApp.Models;

namespace ClientBaseControlWebApp.Data.Services
{
	public interface IClientsService
	{
		public Task<IEnumerable<Client>> GetAll();
		public Task<Client> GetByIdAsync(int id);
		public Task AddAsync(Client client);
		public Client Update(int id, Client newClient);
		public void Delete(int id);
	}
}
