using System.ComponentModel.DataAnnotations;

namespace ClientBaseControlWebApp.Models
{
    public class ProcedureType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field if required")]
        public string Name { get; set; }

        public List<ProcedureRecord>? procedureRecords { get; set; }
    }
}
