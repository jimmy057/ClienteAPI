using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClienteAPI.Modelo
{
	public class Cliente
	{
		[Key]
		public int Id { get; set; }

		[Column(TypeName = "text")]
		public string Nombre { get; set; }

		[Column(TypeName = "text")]
		public string Apellido { get; set; }

		[Column(TypeName = "text")]
		public string Email { get; set; }

		[Column(TypeName = "text")]
		public string Telefono { get; set; }

		[Column(TypeName = "text")]
		public string Direccion { get; set; }
	}
}
