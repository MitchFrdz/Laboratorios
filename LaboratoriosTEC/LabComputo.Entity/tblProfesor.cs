namespace LabComputo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProfesor")]
    public partial class tblProfesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProfesor()
        {
            tblClases = new HashSet<tblClase>();
        }

        [Key]
        public int ProfesorID { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(15)]
        public string NumeroControl { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; }

        public decimal Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNac { get; set; }

        public byte[] Firma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClase> tblClases { get; set; }
    }
}
