using ClientBaseControlWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientBaseControlWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Record_Material>().HasKey(rm => new
            {
                rm.RecordId,
                rm.MaterialId
            });

            // Adding custom many to many relationships
            builder.Entity<Record_Material>().HasOne(r => r.Record).WithMany(rm => rm.Records_Materials).HasForeignKey(r => r.RecordId);
            builder.Entity<Record_Material>().HasOne(m => m.Material).WithMany(rm => rm.Records_Materials).HasForeignKey(m => m.MaterialId);



            base.OnModelCreating(builder);

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Appearance> Appearances { get; set; }
        public DbSet<ProcedureRecord> ProcedureRecords { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Record_Material> Records_Materials { get; set; }
    }
}