namespace LabComputo.Entity
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

		public virtual DbSet<tblAccesoAlumno> tblAccesoAlumnoes { get; set; }
		public virtual DbSet<tblAlumno> tblAlumnoes { get; set; }
		public virtual DbSet<tblClase> tblClases { get; set; }
		public virtual DbSet<tblComputadora> tblComputadoras { get; set; }
		public virtual DbSet<tblLaboratorio> tblLaboratorios { get; set; }
		public virtual DbSet<tblObjetosOlvidado> tblObjetosOlvidados { get; set; }
		public virtual DbSet<tblProfesor> tblProfesors { get; set; }
		public virtual DbSet<tblUsuario> tblUsuarios { get; set; }

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
				.HasMany(e => e.tblObjetosOlvidados)
				.WithRequired(e => e.tblLaboratorio)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<tblProfesor>()
				.Property(e => e.Telefono)
				.HasPrecision(15, 0);

			modelBuilder.Entity<tblUsuario>()
				.HasMany(e => e.tblUsuario1)
				.WithRequired(e => e.tblUsuario2)
				.HasForeignKey(e => e.CreatedBy);

			modelBuilder.Entity<tblUsuario>()
				.HasMany(e => e.tblUsuario11)
				.WithOptional(e => e.tblUsuario3)
				.HasForeignKey(e => e.DeletedBy);

			modelBuilder.Entity<tblUsuario>()
				.HasMany(e => e.tblUsuario12)
				.WithRequired(e => e.tblUsuario4)
				.HasForeignKey(e => e.UpdatedBy);
		}
	}
}
