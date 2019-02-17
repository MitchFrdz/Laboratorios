namespace LabComputo.Data
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class LaboratoriosDB : DbContext
	{
		public LaboratoriosDB()
			: base("name=LaboratoriosDB")
		{
		}

		public virtual DbSet<sysdiagram> sysdiagram { get; set; }
		public virtual DbSet<tblAccesoAlumno> tblAccesoAlumno { get; set; }
		public virtual DbSet<tblAlumno> tblAlumno { get; set; }
		public virtual DbSet<tblClase> tblClase { get; set; }
		public virtual DbSet<tblComputadora> tblComputadora { get; set; }
		public virtual DbSet<tblLaboratorio> tblLaboratorio { get; set; }
		public virtual DbSet<tblObjetosOlvidados> tblObjetosOlvidados { get; set; }
		public virtual DbSet<tblProfesor> tblProfesor { get; set; }
		public virtual DbSet<tblUsuario> tblUsuario { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<tblAlumno>()
				.Property(e => e.Telefono)
				.HasPrecision(13, 0);

			modelBuilder.Entity<tblLaboratorio>()
				.Property(e => e.Nombre)
				.IsUnicode(false);

			modelBuilder.Entity<tblLaboratorio>()
				.Property(e => e.Edificio)
				.IsUnicode(false);

			modelBuilder.Entity<tblLaboratorio>()
				.HasMany(e => e.tblObjetosOlvidado)
				.WithRequired(e => e.tblLaboratorio)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<tblProfesor>()
				.Property(e => e.Telefono)
				.HasPrecision(15, 0);

			modelBuilder.Entity<tblUsuario>()
				.HasMany(e => e.tblUsuario1)
				.WithOptional(e => e.tblUsuario2)
				.HasForeignKey(e => e.CreatedBy);

			modelBuilder.Entity<tblUsuario>()
				.HasMany(e => e.tblUsuario11)
				.WithOptional(e => e.tblUsuario3)
				.HasForeignKey(e => e.DeletedBy);

			modelBuilder.Entity<tblUsuario>()
				.HasMany(e => e.tblUsuario12)
				.WithOptional(e => e.tblUsuario4)
				.HasForeignKey(e => e.UpdatedBy);
		}
	}
}
