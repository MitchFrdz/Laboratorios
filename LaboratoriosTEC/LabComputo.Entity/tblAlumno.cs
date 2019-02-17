namespace LabComputo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblAlumno")]
    public partial class tblAlumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAlumno()
        {
            tblAccesoAlumnoes = new HashSet<tblAccesoAlumno>();
        }

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

        [Required]
        public byte[] Foto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNac { get; set; }

        public decimal? Telefono { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAccesoAlumno> tblAccesoAlumnoes { get; set; }
    }
}
