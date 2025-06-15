using System.ComponentModel.DataAnnotations;

namespace SIGU.Aplicacion.DTOs
{
	public class EventoDeportivoDTO
	{
		public string Nombre { get; set; } = "";
		public string Descripcion { get; set; } = "";
		public DateTime FechaHoraInicio { get; set; }
		public double DuracionHoras { get; set; }
		public int CupoMaximo { get; set; }
		public int ResponsableID { get; set; }
	}
}