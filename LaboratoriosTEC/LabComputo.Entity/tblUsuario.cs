namespace LabComputo.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblUsuario")]
    public partial class tblUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUsuario()
        {
            tblUsuario1 = new HashSet<tblUsuario>();
            tblUsuario11 = new HashSet<tblUsuario>();
            tblUsuario12 = new HashSet<tblUsuario>();
        }

        [Key]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(20)]
        public string Correo { get; set; }

        [Required]
        public byte[] Contraseña { get; set; }

        public TimeSpan? Duracion { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuario> tblUsuario1 { get; set; }

        public virtual tblUsuario tblUsuario2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuario> tblUsuario11 { get; set; }

        public virtual tblUsuario tblUsuario3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuario> tblUsuario12 { get; set; }

        public virtual tblUsuario tblUsuario4 { get; set; }
    }
}
