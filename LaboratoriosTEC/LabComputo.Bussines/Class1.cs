using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabComputo.Data;

namespace LabComputo.Bussines
{
    public class Class1
    {
		/// <summary>
		/// adsfghjbkl
		/// </summary>
		/// <param name="a">id de clase</param>
		public void loquequieras(int a)
		{
			
			LaboratoriosDB lab = new LaboratoriosDB();
			tblAccesoAlumno alumno = lab.tblAccesoAlumno.FirstOrDefault();
			//alumno.tblComputadora.LaboratorioID

		}
    }
}
