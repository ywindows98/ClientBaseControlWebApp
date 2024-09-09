using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientBaseControlWebApp.Models
{
    public class Appearance
    {
        [Key]
        public int Id { get; set; }
        public string SkinType { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string Capillaries { get; set; }
        public string SkinRedness { get; set; }
        public string Tan { get; set; }
        public string MembraneColor { get; set; }
        public string NeedleType { get; set; }
        public string Comment { get; set; }

        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
    }
}
