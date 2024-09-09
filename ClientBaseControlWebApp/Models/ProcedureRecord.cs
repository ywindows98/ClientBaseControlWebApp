using System.ComponentModel.DataAnnotations;

namespace ClientBaseControlWebApp.Models
{
    public class ProcedureRecord
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ProcedureType { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }s
    }
}
