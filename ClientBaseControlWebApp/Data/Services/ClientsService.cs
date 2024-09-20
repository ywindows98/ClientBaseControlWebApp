using ClientBaseControlWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientBaseControlWebApp.Data.Services
{
	public class ClientsService : IGenericCrudService<Client>, IGenericSearchableService<Client>
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

		public async Task<IEnumerable<Client>> GetAllAsync()
		{
			var result = await _context.Clients.Include(c => c.Appearance).ToListAsync();
			return result;
		}

		public async Task<Client> GetByIdAsync(int id)
		{
			var result = await _context.Clients.Include(c => c.Appearance).FirstOrDefaultAsync(x => x.Id == id);

			return result;
		}

		// Name and surname
		public async Task<IEnumerable<Client>> GetBySearchValue(string searchValue)
		{
			var result = await _context.Clients.Where(c => string.Concat(c.Name," ", c.Surname).ToLower().Contains(searchValue.ToLower())).ToListAsync();
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
