using System.ComponentModel.DataAnnotations;

namespace ClientBaseControlWebApp.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field if required")]
        public string Name { get; set; }    
        public string? Description { get; set; }
        [Required(ErrorMessage = "This field if required")]
        public float Amount { get; set; }
        [Required(ErrorMessage = "This field if required")]
        public int UnitsOfMeasurement { get; set; }
        [Required(ErrorMessage = "This field if required")]
        public int MaterialType { get; set; }
        public List<Record_Material>? Records_Materials { get; set; }
    }
}
