using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practica5_ProyectoVenta.Models;

public partial class ProyectoVentaContext : DbContext
{
    public ProyectoVentaContext()
    {
    }

    public ProyectoVentaContext(DbContextOptions<ProyectoVentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__cliente__7B86132F922ABAC9");

            entity.ToTable("cliente");

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IddetalleVenta).HasName("PK__detalle___7CFD2ACAC95D343A");

            entity.ToTable("detalle_venta");

            entity.Property(e => e.IddetalleVenta).HasColumnName("iddetalleVenta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Subtotal)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_v__idpro__5165187F");

            entity.HasOne(d => d.IdventaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Idventa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_v__idven__5070F446");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__producto__DC53BE3C91324C90");

            entity.ToTable("producto");

            entity.Property(e => e.Idproducto).HasColumnName("idproducto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Marca)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Precio)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Producto1)
                .IsUnicode(false)
                .HasColumnName("producto");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__venta__F82D1AFB2D7B27F5");

            entity.ToTable("venta");

            entity.Property(e => e.Idventa).HasColumnName("idventa");
            entity.Property(e => e.CodigoVenta)
                .IsUnicode(false)
                .HasColumnName("codigoVenta");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idcliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__venta__idcliente__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
