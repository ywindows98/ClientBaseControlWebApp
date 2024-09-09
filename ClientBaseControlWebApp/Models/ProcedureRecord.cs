using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientBaseControlWebApp.Models
{
    public class ProcedureRecord
    {
        [Key]
        public int Id { get; set; }
        public string ProcedureType { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
    }
}
