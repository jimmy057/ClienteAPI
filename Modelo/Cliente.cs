using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Modelo
{
	public class Cliente
	{
		[Key]
		public required int Id { get; set; }

		[Column(TypeName = "text")]
		public required string Nombre { get; set; }

		[Column(TypeName = "text")]
		public required string Apellido { get; set; }

		[Column(TypeName = "text")]
		public required string Email { get; set; }

		[Column(TypeName = "text")]
		public required string Telefono { get; set; }

		[Column(TypeName = "text")]
		public required  string Direccion { get; set; }
	}
}
