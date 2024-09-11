using System.ComponentModel.DataAnnotations.Schema;

namespace ClientBaseControlWebApp.Models
{
    public class Record_Material
    {
        public int RecordId { get; set; }
        [ForeignKey("RecordId")]
        public ProcedureRecord Record { get; set; }

        public int MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
    }
}
