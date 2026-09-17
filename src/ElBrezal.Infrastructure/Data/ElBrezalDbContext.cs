using System;
using System.Collections.Generic;
using ElBrezal.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElBrezal.Infrastructure.Data;

public partial class ElBrezalDbContext : DbContext
{
    public ElBrezalDbContext(DbContextOptions<ElBrezalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<EstadosCuentaCliente> EstadosCuentaCliente { get; set; }

    public virtual DbSet<Familias> Familias { get; set; }

    public virtual DbSet<Localidades> Localidades { get; set; }

    public virtual DbSet<Marcas> Marcas { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Provincias> Provincias { get; set; }

    public virtual DbSet<SituacionesImpositivas> SituacionesImpositivas { get; set; }

    public virtual DbSet<Unidades> Unidades { get; set; }

    public virtual DbSet<Vendedores> Vendedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.Property(e => e.CUIT)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.DNI)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IngresosBrutos)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Matricula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EstadoCuenta).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EstadoCuentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_EstadosCuentaCliente");

            entity.HasOne(d => d.Localidad).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.LocalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_Localidades");

            entity.HasOne(d => d.SituacionImpositiva).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.SituacionImpositivaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_SituacionesImpositivas");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.VendedorId)
                .HasConstraintName("FK_Clientes_Vendedores");
        });

        modelBuilder.Entity<EstadosCuentaCliente>(entity =>
        {
            entity.HasIndex(e => e.Nombre, "UQ_EstadosCuentaCliente_Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Familias>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Localidades>(entity =>
        {
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Provincia).WithMany(p => p.Localidades)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Localidades_Provincias");
        });

        modelBuilder.Entity<Marcas>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.Property(e => e.CUIT)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IngresosBrutos)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Observacion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Localidad).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.LocalidadId)
                .HasConstraintName("FK_Proveedores_Localidades");

            entity.HasOne(d => d.SituacionImpositiva).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.SituacionImpositivaId)
                .HasConstraintName("FK_Proveedores_SituacionesImpositivas");
        });

        modelBuilder.Entity<Provincias>(entity =>
        {
            entity.HasIndex(e => e.Nombre, "UQ_Provincias_Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SituacionesImpositivas>(entity =>
        {
            entity.HasIndex(e => e.Nombre, "UQ_SituacionesImpositivas_Nombre").IsUnique();

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Unidades>(entity =>
        {
            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendedores>(entity =>
        {
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Localidad).WithMany(p => p.Vendedores)
                .HasForeignKey(d => d.LocalidadId)
                .HasConstraintName("FK_Vendedores_Localidades");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
