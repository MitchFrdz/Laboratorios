//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabComputoWeb.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAccesoAlumno
    {
        public int AccesoID { get; set; }
        public Nullable<int> AlumnoID { get; set; }
        public Nullable<int> ComputadoraID { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.TimeSpan HoraE { get; set; }
        public Nullable<System.TimeSpan> HoraS { get; set; }
    
        public virtual tblAlumno tblAlumno { get; set; }
        public virtual tblComputadora tblComputadora { get; set; }
    }
}
