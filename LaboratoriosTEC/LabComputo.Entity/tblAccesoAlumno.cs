namespace LabComputo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAccesoAlumno")]
    public partial class tblAccesoAlumno
    {
        [Key]
        public int AccesoID { get; set; }

        public int? AlumnoID { get; set; }

        public int? ComputadoraID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public TimeSpan HoraE { get; set; }

        public TimeSpan? HoraS { get; set; }

        public virtual tblAlumno tblAlumno { get; set; }

        public virtual tblComputadora tblComputadora { get; set; }
    }
}
