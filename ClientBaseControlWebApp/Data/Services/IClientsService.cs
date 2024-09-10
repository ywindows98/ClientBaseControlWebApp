using ClientBaseControlWebApp.Models;

namespace ClientBaseControlWebApp.Data.Services
{
	public interface IClientsService
	{
		public Task<IEnumerable<Client>> GetAll();
		public Client GetById(int id);
		public void Add(Client client);
		public Client Update(int id, Client newClient);
		public void Delete(int id);
	}
}
