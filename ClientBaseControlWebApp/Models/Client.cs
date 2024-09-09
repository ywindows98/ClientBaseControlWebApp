using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientBaseControlWebApp.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string InitialComment { get; set; }
        public int NumberOfProcedures { get; set; }
        public string AllergiesComment { get; set; }
        public string MainComment { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IndicationColor { get; set; }

        // Relationships
        public List<ProcedureRecord> ProcedureRecords { get; set; }

        public int AppearanceId { get; set; }
        [ForeignKey(nameof(AppearanceId))]
        public Appearance Appearance { get; set; }

    }
}
