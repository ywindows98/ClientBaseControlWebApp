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

		public async Task DeleteAsync(int id)
		{
			var client = await GetByIdAsync(id);
			_context.Clients.Remove(client);
			await _context.SaveChangesAsync();
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

		public async Task<Client> UpdateAsync(int id, Client newClient)
		{
			_context.Clients.Update(newClient);
			await _context.SaveChangesAsync();
			return newClient;
		}
	}
}
