namespace LabComputo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblComputadora")]
    public partial class tblComputadora
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblComputadora()
        {
            tblAccesoAlumnoes = new HashSet<tblAccesoAlumno>();
        }

        [Key]
        public int ComputadoraID { get; set; }

        public int? LaboratorioID { get; set; }

        public int NumeroComputadora { get; set; }

        public bool Funciona { get; set; }

        public string Nota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccesoAlumno> tblAccesoAlumnoes { get; set; }

        public virtual tblLaboratorio tblLaboratorio { get; set; }
    }
}
