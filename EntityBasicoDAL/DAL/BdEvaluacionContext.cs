using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityBasicoDAL.DAL;

//En esta clase establecemos el CRUD con los DbSet, es decir las operaciones de la BBDD, 
//y el contexto de la base de datos para poder trabajar con ella en nuestro codigo.
public partial class BdEvaluacionContext : DbContext
{
    public BdEvaluacionContext()
    {
    }

    public BdEvaluacionContext(DbContextOptions<BdEvaluacionContext> options)
        : base(options)
    {
    }

    //Con estos DbSet realuzamos las opetaciones del CRUD.
    public virtual DbSet<EvaCatEvaluacion> EvaCatEvaluacions { get; set; }

    public virtual DbSet<EvaTchNotasEvaluacion> EvaTchNotasEvaluacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=bd_evaluacion;User Id=postgres;Password=fp13DAW");

    //Con este metodo establecemos las entidades para luego poder llevarla a la vista y trabajar con
    //ellas en el controlador. 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvaCatEvaluacion>(entity =>
        {
            entity.HasKey(e => e.CodEvaluacion).HasName("eva_cat_evaluacion_pkey");

            entity.ToTable("eva_cat_evaluacion", "sc_evaluacion");

            entity.Property(e => e.CodEvaluacion)
                .HasColumnType("character varying")
                .HasColumnName("cod_evaluacion");
            entity.Property(e => e.DescEvaluacion)
                .HasColumnType("character varying")
                .HasColumnName("desc_evaluacion");
        });

        modelBuilder.Entity<EvaTchNotasEvaluacion>(entity =>
        {
            entity.HasKey(e => e.IdNotaEvaluacion).HasName("eva_tch_notas_evaluacion_pkey");

            entity.ToTable("eva_tch_notas_evaluacion", "sc_evaluacion");

            entity.Property(e => e.IdNotaEvaluacion).HasColumnName("id_nota_evaluacion");
            entity.Property(e => e.CodAlumno)
                .HasColumnType("character varying")
                .HasColumnName("cod_alumno");
            entity.Property(e => e.CodEvaluacion)
                .HasColumnType("character varying")
                .HasColumnName("cod_evaluacion");
            entity.Property(e => e.MdFch)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("md_fch");
            entity.Property(e => e.MdUuid)
                .HasColumnType("character varying")
                .HasColumnName("md_uuid");
            entity.Property(e => e.NotaEvaluacion).HasColumnName("nota_evaluacion");

            entity.HasOne(d => d.CodEvaluacionNavigation).WithMany(p => p.EvaTchNotasEvaluacions)
                .HasForeignKey(d => d.CodEvaluacion)
                .HasConstraintName("eva_tch_notas_evaluacion_FK_eva_cat_evaluacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
