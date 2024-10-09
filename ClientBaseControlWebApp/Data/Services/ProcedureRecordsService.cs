using ClientBaseControlWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientBaseControlWebApp.Data.Services
{
    public class ProcedureRecordsService : IGenericCrudService<ProcedureRecord>, IGenericSearchableService<ProcedureRecord>
    {
        private readonly ApplicationDbContext _context;

        public ProcedureRecordsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ProcedureRecord procedureRecord)
        {
            await _context.ProcedureRecords.AddAsync(procedureRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var procedureRecord = await GetByIdAsync(id);
            _context.ProcedureRecords.Remove(procedureRecord);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProcedureRecord>> GetAllAsync()
        {
            var result = await _context.ProcedureRecords.Include(pr => pr.ProcedureType).Include(pr => pr.Client).Include(pr => pr.Records_Materials).ThenInclude(rm => rm.Material).ToListAsync();
            return result;
        }

        public async Task<ProcedureRecord> GetByIdAsync(int id)
        {
            var result = await _context.ProcedureRecords.Include(pr => pr.ProcedureType).Include(pr => pr.Client).Include(pr => pr.Records_Materials).ThenInclude(rm => rm.Material).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        // Name and surname
        public async Task<IEnumerable<ProcedureRecord>> GetBySearchValue(string searchValue)
        {
            var result = await _context.ProcedureRecords.Where(p => string.Concat(p.ProcedureType.Name, " ", p.Client.Name, " ", p.Client.Surname).ToLower().Contains(searchValue.ToLower())).ToListAsync();
            return result;
        }

        public async Task<ProcedureRecord> UpdateAsync(int id, ProcedureRecord newProcedureRecord)
        {
            ProcedureRecord currentProcedureRecord = await GetByIdAsync(newProcedureRecord.Id);
            
            currentProcedureRecord.Id = newProcedureRecord.Id;
            currentProcedureRecord.Date = newProcedureRecord.Date;
            currentProcedureRecord.Comment = newProcedureRecord.Comment;
			currentProcedureRecord.ClientId = newProcedureRecord.ClientId;
			currentProcedureRecord.Records_Materials = newProcedureRecord.Records_Materials;
			currentProcedureRecord.ProcedureTypeId = newProcedureRecord.ProcedureTypeId;

			await _context.SaveChangesAsync();

            return currentProcedureRecord;
        }
    }
}
