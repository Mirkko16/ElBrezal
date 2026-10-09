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

    public virtual DbSet<AlicuotasIVA> AlicuotasIVA { get; set; }

    public virtual DbSet<Clientes> Clientes { get; set; }

    public virtual DbSet<Comprobantes> Comprobantes { get; set; }

    public virtual DbSet<ComprobantesDetalle> ComprobantesDetalle { get; set; }

    public virtual DbSet<CondicionesVenta> CondicionesVenta { get; set; }

    public virtual DbSet<Config> Config { get; set; }

    public virtual DbSet<EstadosCuentaCliente> EstadosCuentaCliente { get; set; }

    public virtual DbSet<Familias> Familias { get; set; }

    public virtual DbSet<Localidades> Localidades { get; set; }

    public virtual DbSet<Marcas> Marcas { get; set; }

    public virtual DbSet<NumeracionesComprobante> NumeracionesComprobante { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Provincias> Provincias { get; set; }

    public virtual DbSet<SituacionesImpositivas> SituacionesImpositivas { get; set; }

    public virtual DbSet<TiposComprobante> TiposComprobante { get; set; }

    public virtual DbSet<Unidades> Unidades { get; set; }

    public virtual DbSet<Vendedores> Vendedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlicuotasIVA>(entity =>
        {
            entity.HasIndex(e => e.Porcentaje, "UQ_AlicuotasIVA_Porcentaje").IsUnique();

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(5, 2)");
        });

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

        modelBuilder.Entity<Comprobantes>(entity =>
        {
            entity.HasIndex(e => e.ComprobanteOrigenId, "IX_Comprobantes_ComprobanteOrigenId");

            entity.HasIndex(e => new { e.TipoComprobanteId, e.PuntoVenta, e.Numero }, "UQ_Comprobantes_Numeracion").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Comprobantes_CreatedAt");
            entity.Property(e => e.MontoVariacion).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Observacion).HasMaxLength(500);
            entity.Property(e => e.PorcentajeVariacion).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprobantes_Clientes");

            entity.HasOne(d => d.ComprobanteOrigen).WithMany(p => p.InverseComprobanteOrigen)
                .HasForeignKey(d => d.ComprobanteOrigenId)
                .HasConstraintName("FK_Comprobantes_ComprobanteOrigen");

            entity.HasOne(d => d.CondicionVenta).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.CondicionVentaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprobantes_CondicionesVenta");

            entity.HasOne(d => d.SituacionImpositiva).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.SituacionImpositivaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprobantes_SituacionesImpositivas");

            entity.HasOne(d => d.TipoComprobante).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.TipoComprobanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprobantes_TiposComprobante");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.VendedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comprobantes_Vendedores");
        });

        modelBuilder.Entity<ComprobantesDetalle>(entity =>
        {
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Comprobante).WithMany(p => p.ComprobantesDetalle)
                .HasForeignKey(d => d.ComprobanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobantesDetalle_Comprobantes");

            entity.HasOne(d => d.Producto).WithMany(p => p.ComprobantesDetalle)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComprobantesDetalle_Productos");
        });

        modelBuilder.Entity<CondicionesVenta>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasIndex(e => e.Clave, "UQ_Config_Clave").IsUnique();

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.Valor).HasMaxLength(500);
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

        modelBuilder.Entity<NumeracionesComprobante>(entity =>
        {
            entity.HasIndex(e => new { e.TipoComprobanteId, e.PuntoVenta }, "UQ_NumeracionesComprobante_Tipo_PuntoVenta").IsUnique();

            entity.HasOne(d => d.TipoComprobante).WithMany(p => p.NumeracionesComprobante)
                .HasForeignKey(d => d.TipoComprobanteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NumeracionesComprobante_TiposComprobante");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.Property(e => e.AlicuotaIVAId).HasDefaultValue(3, "DF_Productos_AlicuotaIVAId");
            entity.Property(e => e.Costo).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FechaAlta).HasDefaultValueSql("(sysdatetime())", "DF_Productos_FechaAlta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PrecioContado).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PrecioCuentaCorriente).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PrecioReventa).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.RentabilidadContado).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.RentabilidadCuentaCorriente).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.RentabilidadReventa).HasColumnType("decimal(7, 2)");
            entity.Property(e => e.Stock).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.StockMinimo).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.AlicuotaIVA).WithMany(p => p.Productos)
                .HasForeignKey(d => d.AlicuotaIVAId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_AlicuotasIVA");

            entity.HasOne(d => d.Familia).WithMany(p => p.Productos)
                .HasForeignKey(d => d.FamiliaId)
                .HasConstraintName("FK_Productos_Familias");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK_Productos_Marcas");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK_Productos_Proveedores");

            entity.HasOne(d => d.Unidad).WithMany(p => p.Productos)
                .HasForeignKey(d => d.UnidadId)
                .HasConstraintName("FK_Productos_Unidades");
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
            entity.Property(e => e.Porce).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<TiposComprobante>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abreviatura).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Signo).HasDefaultValue((short)1, "DF_TiposComprobante_Signo");
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
