using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace crudBodega.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adm> Adms { get; set; } = null!;
        public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST= (ADDRESS=(COMMUNITY=tcpcom.world)(PROTOCOL=tcp)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SID=xe))); User ID=testuser;Password=securepassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TESTUSER")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Adm>(entity =>
            {
                entity.HasKey(e => e.Rut);

                entity.ToTable("ADM");

                entity.Property(e => e.Rut)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RUT");

                entity.Property(e => e.Pass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASS");
            });

            modelBuilder.Entity<Ingrediente>(entity =>
            {
                entity.HasKey(e => e.Idingrediente);

                entity.ToTable("INGREDIENTE");

                entity.Property(e => e.Idingrediente)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDINGREDIENTE");

                entity.Property(e => e.Nombreingrediente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREINGREDIENTE");

                entity.Property(e => e.Precioingrediente)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRECIOINGREDIENTE");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Idpedido);

                entity.ToTable("PEDIDO");

                entity.Property(e => e.Idpedido)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDPEDIDO");

                entity.Property(e => e.Contpedido)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CONTPEDIDO");

                entity.Property(e => e.Rut)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RUT");

                entity.HasOne(d => d.RutNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Rut)
                    .HasConstraintName("FK_PEDIDO");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto);

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Idproducto)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Descripcionproducto)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONPRODUCTO");

                entity.Property(e => e.Valorproducto)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALORPRODUCTO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
