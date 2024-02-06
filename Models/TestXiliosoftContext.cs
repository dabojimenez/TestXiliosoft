using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestXiliosoft.Models;

public partial class TestXiliosoftContext : DbContext
{
    public TestXiliosoftContext()
    {
    }

    public TestXiliosoftContext(DbContextOptions<TestXiliosoftContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacione> Asignaciones { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Maquinarium> Maquinaria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NER8Q3H; Database=TestXiliosoft; Trusted_Connection=True; Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignacione>(entity =>
        {
            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CedulaNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.Cedula)
                .HasConstraintName("FK_Asignaciones_Empleados");

            entity.HasOne(d => d.SerieNavigation).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.Serie)
                .HasConstraintName("FK_Asignaciones_Maquinaria");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Cedula);

            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Area)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Maquinarium>(entity =>
        {
            entity.HasKey(e => e.Serie);

            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
