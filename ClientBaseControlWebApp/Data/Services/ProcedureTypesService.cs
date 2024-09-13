using Microsoft.EntityFrameworkCore;
using ClientBaseControlWebApp.Models;
using ClientBaseControlWebApp.Data;
using ClientBaseControlWebApp.Data.Services;

namespace ClientBaseControlWebApp.Data.Services
{
    public class ProcedureTypesService :IGenericCrudService<ProcedureType>, IGenericSearchableService<ProcedureType>
    {
        private readonly ApplicationDbContext _context;

        public ProcedureTypesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ProcedureType procedureType)
        {
            await _context.ProcedureTypes.AddAsync(procedureType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var procedureType = await GetByIdAsync(id);
            _context.ProcedureTypes.Remove(procedureType);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProcedureType>> GetAllAsync()
        {
            var result = await _context.ProcedureTypes.ToListAsync();
            return result;
        }

        public async Task<ProcedureType> GetByIdAsync(int id)
        {
            var result = await _context.ProcedureTypes.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        // Name and surname
        public async Task<IEnumerable<ProcedureType>> GetBySearchValue(string searchValue)
        {
            var result = await _context.ProcedureTypes.Where(pt => pt.Name.ToLower().Contains(searchValue.ToLower())).ToListAsync();
            return result;
        }

        public async Task<ProcedureType> UpdateAsync(int id, ProcedureType newProcedureType)
        {
            _context.ProcedureTypes.Update(newProcedureType);
            await _context.SaveChangesAsync();
            return newProcedureType;
        }
    }
}
