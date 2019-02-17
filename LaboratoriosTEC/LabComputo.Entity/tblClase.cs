namespace LabComputo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblClase")]
    public partial class tblClase
    {
        [Key]
        public int ClaseID { get; set; }

        public int? LaboratorioID { get; set; }

        public int? ProfesorID { get; set; }

        public DateTime FechaApartado { get; set; }

        public bool? Registro { get; set; }

        public virtual tblLaboratorio tblLaboratorio { get; set; }

        public virtual tblProfesor tblProfesor { get; set; }
    }
}
