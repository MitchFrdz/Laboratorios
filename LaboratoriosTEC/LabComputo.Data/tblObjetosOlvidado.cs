namespace LabComputo.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblObjetosOlvidados")]
    public partial class tblObjetosOlvidados
    {
        [Key]
        public int ObjetosOlvidadosID { get; set; }

        public int LaboratorioID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public byte[] Foto { get; set; }

        [StringLength(600)]
        public string Nota { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public virtual tblLaboratorio tblLaboratorio { get; set; }
    }
}
