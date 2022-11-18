using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kitchenApp.Models
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
        public virtual DbSet<Bebidum> Bebida { get; set; } = null!;
        public virtual DbSet<Egreso> Egresos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Ingrediente> Ingredientes { get; set; } = null!;
        public virtual DbSet<Ingreso> Ingresos { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Plato> Platos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
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

            modelBuilder.Entity<Bebidum>(entity =>
            {
                entity.HasKey(e => e.Idbebida);

                entity.ToTable("BEBIDA");

                entity.Property(e => e.Idbebida)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDBEBIDA");

                entity.Property(e => e.Nombrebebida)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREBEBIDA");

                entity.Property(e => e.Valorbebida)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALORBEBIDA");
            });

            modelBuilder.Entity<Egreso>(entity =>
            {
                entity.HasKey(e => e.Idegreso);

                entity.ToTable("EGRESO");

                entity.Property(e => e.Idegreso)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDEGRESO");

                entity.Property(e => e.Descripcionegreso)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONEGRESO");

                entity.Property(e => e.Fechaegreso)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAEGRESO");

                entity.Property(e => e.Montoegreso)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTOEGRESO");
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
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDINGREDIENTE");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CANTIDAD");

                entity.Property(e => e.Nombreingrediente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREINGREDIENTE");

                entity.Property(e => e.Precioingrediente)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRECIOINGREDIENTE");

                entity.Property(e => e.Unidadmedida)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UNIDADMEDIDA");
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasKey(e => e.Idingreso);

                entity.ToTable("INGRESO");

                entity.Property(e => e.Idingreso)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDINGRESO");

                entity.Property(e => e.Descripcioningreso)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONINGRESO");

                entity.Property(e => e.Fechaingreso)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAINGRESO");

                entity.Property(e => e.Montoingreso)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MONTOINGRESO");
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
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDORDEN");

                entity.Property(e => e.Contenidoorden)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("CONTENIDOORDEN");

                entity.Property(e => e.Estadoorden)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ESTADOORDEN");

                entity.Property(e => e.Idmesa)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDMESA");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER")
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
                    .ValueGeneratedOnAdd()
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
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPLATO");

                entity.Property(e => e.Idreceta)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDRECETA");

                entity.Property(e => e.Nombreplato)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREPLATO");

                entity.HasOne(d => d.IdrecetaNavigation)
                    .WithMany(p => p.Platos)
                    .HasForeignKey(d => d.Idreceta)
                    .HasConstraintName("FK_IDRECETA");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto);

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Idproducto)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPRODUCTO");

                entity.Property(e => e.Descripcionproducto)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCIONPRODUCTO");

                entity.Property(e => e.Valorproducto)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VALORPRODUCTO");
            });

            modelBuilder.Entity<Recetum>(entity =>
            {
                entity.HasKey(e => e.Idreceta);

                entity.ToTable("RECETA");

                entity.Property(e => e.Idreceta)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDRECETA");

                entity.Property(e => e.Idingrediente)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDINGREDIENTE");

                entity.Property(e => e.Idproducto)
                    .HasColumnType("NUMBER")
                    .HasColumnName("IDPRODUCTO");

                entity.HasOne(d => d.IdingredienteNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.Idingrediente)
                    .HasConstraintName("FK_RECETA1");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Receta)
                    .HasForeignKey(d => d.Idproducto)
                    .HasConstraintName("FK_RECETA2");
            });

            modelBuilder.HasSequence("INGRESOBEBIDA");

            modelBuilder.HasSequence("INGRESOEGRESO");

            modelBuilder.HasSequence("INGRESOINGEDIENTE");

            modelBuilder.HasSequence("INGRESOINGRESO");

            modelBuilder.HasSequence("INGRESOORDEN");

            modelBuilder.HasSequence("INGRESOPEDIDO");

            modelBuilder.HasSequence("INGRESOPLATO");

            modelBuilder.HasSequence("INGRESOPRODUCTO");

            modelBuilder.HasSequence("INGRESORECETA");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
