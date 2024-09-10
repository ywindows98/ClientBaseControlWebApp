using ClientBaseControlWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientBaseControlWebApp.Data.Services
{
	public class ClientsService : IClientsService
	{
		private readonly ApplicationDbContext _context;

		public ClientsService(ApplicationDbContext context)
		{
			_context = context;
		}
		public void Add(Client client)
		{
			_context.Clients.Add(client);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Client>> GetAll()
		{
			var result = await _context.Clients.ToListAsync();
			return result;
		}

		public Client GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Client Update(int id, Client newClient)
		{
			throw new NotImplementedException();
		}
	}
}
