namespace LabComputo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLaboratorio")]
    public partial class tblLaboratorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblLaboratorio()
        {
            tblClases = new HashSet<tblClase>();
            tblComputadoras = new HashSet<tblComputadora>();
            tblObjetosOlvidados = new HashSet<tblObjetosOlvidado>();
        }

        [Key]
        public int LaboratorioID { get; set; }

        [Required]
        [StringLength(10)]
        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        [StringLength(10)]
        public string Edificio { get; set; }

        public bool Disponible { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClase> tblClases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblComputadora> tblComputadoras { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblObjetosOlvidado> tblObjetosOlvidados { get; set; }
    }
}
