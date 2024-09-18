using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClientBaseControlWebApp.Models
{
	public class ProcedureRecordViewModel
	{
		
		public int Id { get; set; }
		[Required(ErrorMessage = "This field if required")]
		public DateTime Date { get; set; }
		public string? Comment { get; set; }

		[Required(ErrorMessage = "This field if required")]
		public int ClientId { get; set; }

		[Required(ErrorMessage = "This field if required")]
		public int ProcedureTypeId { get; set; }

		public string? SelectedMaterialIds { get; set; }
		public IEnumerable<Material>? AvailableMaterials { get; set; }
		public IEnumerable<ProcedureType>? AvailableProcedureTypes { get; set; }
		public IEnumerable<Client>? AvailableClients { get; set; }
	}
}
