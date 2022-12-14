using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace clientwebapp.Models
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
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Plato> Platos { get; set; } = null!;
        public virtual DbSet<Recetum> Receta { get; set; } = null!;

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

                entity.HasOne(d => d.RutNavigation)
                    .WithOne(p => p.Adm)
                    .HasForeignKey<Adm>(d => d.Rut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADM");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Rut);

                entity.ToTable("EMPLEADO");

                entity.Property(e => e.Rut)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RUT");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
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

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasKey(e => e.Idmesa);

                entity.ToTable("MESA");

                entity.Property(e => e.Idmesa)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDMESA");

                entity.Property(e => e.Aforomaximo)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AFOROMAXIMO");

                entity.Property(e => e.Estadomesa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTADOMESA");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.HasKey(e => e.Idorden);

                entity.ToTable("ORDEN");

                entity.Property(e => e.Idorden)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDORDEN");

                entity.Property(e => e.Contenidoorden)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CONTENIDOORDEN");

                entity.Property(e => e.Estadopedido)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ESTADOPEDIDO");

                entity.Property(e => e.Idmesa)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDMESA");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TOTAL");

                entity.HasOne(d => d.IdmesaNavigation)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.Idmesa)
                    .HasConstraintName("FK_ORDEN");
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

            modelBuilder.Entity<Plato>(entity =>
            {
                entity.HasKey(e => e.Idplato);

                entity.ToTable("PLATO");

                entity.Property(e => e.Idplato)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDPLATO");

                entity.Property(e => e.Aforomaximo)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AFOROMAXIMO");

                entity.Property(e => e.Estadomesa)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESTADOMESA");
            });

            modelBuilder.Entity<Recetum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RECETA");

                entity.Property(e => e.Idingrediente)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDINGREDIENTE");

                entity.Property(e => e.Idplato)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDPLATO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
