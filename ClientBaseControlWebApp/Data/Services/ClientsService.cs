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
		public async Task AddAsync(Client client)
		{
			await _context.Clients.AddAsync(client);
			await _context.SaveChangesAsync();
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

		public async Task<Client> GetByIdAsync(int id)
		{
			var result = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

			return result;
		}

		public Client Update(int id, Client newClient)
		{
			throw new NotImplementedException();
		}
	}
}
