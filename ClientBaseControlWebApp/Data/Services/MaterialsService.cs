using ClientBaseControlWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientBaseControlWebApp.Data.Services
{
    public class MaterialsService : IGenericCrudService<Material>, IGenericSearchableService<Material>
    {
        private readonly ApplicationDbContext _context;

        public MaterialsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Material material)
        {
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var material = await GetByIdAsync(id);
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            var result = await _context.Materials.ToListAsync();
            return result;
        }

        public async Task<Material> GetByIdAsync(int id)
        {
            var result = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        // Name and surname
        public async Task<IEnumerable<Material>> GetBySearchValue(string searchValue)
        {
            var result = await _context.Materials.Where(m => m.Name.ToLower().Contains(searchValue.ToLower())).ToListAsync();
            return result;
        }

        public async Task<Material> UpdateAsync(int id, Material newMaterial)
        {
            _context.Materials.Update(newMaterial);
            await _context.SaveChangesAsync();
            return newMaterial;
        }
    }
}
