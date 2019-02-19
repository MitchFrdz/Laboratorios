using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Threading.Tasks;

namespace LabComputo.Bussines
{
	public class AlumnoesB
	{
		
	}
	public class UploadFileModel
	{
		public UploadFileModel()
		{
			Files = new List<HttpPostedFileBase>();
		}

		public List<HttpPostedFileBase> Files { get; set; }
	}
}
