namespace LabComputo.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Net;
	using System.Web;
	using System.Threading.Tasks;
	using System.IO;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class UploadFileModel
	{
		public UploadFileModel()
		{
			Files = new List<HttpPostedFileBase>();
		}

		public List<HttpPostedFileBase> Files { get; set; }
		[Key]
		public int AlumnoID { get; set; }

		[Required]
		[StringLength(150)]
		public string Nombre { get; set; }

		[Required]
		[StringLength(15)]
		public string NumeroControl { get; set; }

		[StringLength(100)]
		public string Correo { get; set; }

		[Required]
		[StringLength(60)]
		public string Carrera { get; set; }

		public string Foto { get; set; }

		[Column(TypeName = "date")]
		public DateTime? FechaNac { get; set; }

		public decimal? Telefono { get; set; }
	}
}
