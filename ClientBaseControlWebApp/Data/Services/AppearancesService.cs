using ClientBaseControlWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientBaseControlWebApp.Data.Services
{
	public class AppearancesService : IGenericCrudService<Appearance>
	{
		private readonly ApplicationDbContext _context;

		public AppearancesService(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task AddAsync(Appearance appearance)
		{
			await _context.Appearances.AddAsync(appearance); 
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var appearance = await GetByIdAsync(id);
			_context.Appearances.Remove(appearance);
			await _context.SaveChangesAsync(); 
		}

		public async Task<IEnumerable<Appearance>> GetAllAsync()
		{
			var result = await _context.Appearances.ToListAsync();
			return result;
		}

		public async Task<Appearance> GetByIdAsync(int id)
		{
			var result = await _context.Appearances.FirstOrDefaultAsync(x => x.Id == id);

			return result;
		}

		public async Task<Appearance> UpdateAsync(int id, Appearance newAppearance)
		{
			_context.Appearances.Update(newAppearance);
			await _context.SaveChangesAsync();
			return newAppearance;
		}
	}
}
