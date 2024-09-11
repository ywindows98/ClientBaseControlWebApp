using System.ComponentModel.DataAnnotations;

namespace ClientBaseControlWebApp.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public float Amount { get; set; }
        public int UnitsOfMeasurement { get; set; }
        public int MaterialType { get; set; }
        public List<Record_Material> Records_Materials { get; set; }
    }
}
