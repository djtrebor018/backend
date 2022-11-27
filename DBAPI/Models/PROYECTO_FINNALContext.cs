using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBAPI.Models
{
    public partial class PROYECTO_FINNALContext : DbContext
    {
        public PROYECTO_FINNALContext()
        {
        }

        public PROYECTO_FINNALContext(DbContextOptions<PROYECTO_FINNALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autobus> Autobus { get; set; } = null!;
        public virtual DbSet<Choferes> Choferes { get; set; } = null!;
        public virtual DbSet<Destinos> Destinos { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservacions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Rutas> Rutas { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;
        public virtual DbSet<Viajes> Viajes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autobus>(entity =>
            {
                entity.HasKey(e => e.IdAutobus)
                    .HasName("PK__AUTOBUS__5C432F7AD5ADE7E6");

                entity.ToTable("AUTOBUS");

                entity.Property(e => e.IdAutobus).HasColumnName("ID_Autobus");

                entity.Property(e => e.CantidadAsientos).HasColumnName("CANTIDAD_ASIENTOS");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Choferes>(entity =>
            {
                entity.HasKey(e => e.IdChofer)
                    .HasName("PK__CHOFERES__1DDB42E96276E4FF");

                entity.ToTable("CHOFERES");

                entity.Property(e => e.IdChofer).HasColumnName("ID_Chofer");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoriaLicencia).HasColumnName("Categoria_Licencia");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiracionLicencia)
                    .HasColumnType("date")
                    .HasColumnName("Expiracion_Licencia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AutobusNavigation)
                    .WithMany(p => p.Choferes)
                    .HasForeignKey(d => d.Autobus)
                    .HasConstraintName("FK_id_autobus2");
            });

            modelBuilder.Entity<Destinos>(entity =>
            {
                entity.HasKey(e => e.IdDestinos)
                    .HasName("PK__DESTINOS__B7F5B488D717F51B");

                entity.ToTable("DESTINOS");

                entity.Property(e => e.IdDestinos).HasColumnName("ID_Destinos");

                entity.Property(e => e.Destino)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PK__RESERVAC__FE16FD6BD02C095C");

                entity.ToTable("RESERVACION");

                entity.Property(e => e.IdReservacion).HasColumnName("ID_Reservacion");

                entity.Property(e => e.AsientosReservados).HasColumnName("Asientos_Reservados");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");

                entity.Property(e => e.IdViaje).HasColumnName("ID_viaje");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_id_usuario2");

                entity.HasOne(d => d.IdViajeNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.IdViaje)
                    .HasConstraintName("FK_id_viaje");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRoles)
                    .HasName("PK__Rol__30F62993AE2A016C");

                entity.ToTable("Rol");

                entity.Property(e => e.IdRoles).HasColumnName("ID_Roles");

                entity.Property(e => e.Rol1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("Rol");
            });

            modelBuilder.Entity<Rutas>(entity =>
            {
                entity.HasKey(e => e.IdRuta)
                    .HasName("PK__RUTAS__4851E68B36977098");

                entity.ToTable("RUTAS");

                entity.Property(e => e.IdRuta).HasColumnName("ID_Ruta");

                entity.Property(e => e.Estatus).HasColumnName("ESTATUS");

                entity.HasOne(d => d.DestinoNavigation)
                    .WithMany(p => p.RutaDestinoNavigations)
                    .HasForeignKey(d => d.Destino)
                    .HasConstraintName("FK_destino");

                entity.HasOne(d => d.OrigenNavigation)
                    .WithMany(p => p.RutaOrigenNavigations)
                    .HasForeignKey(d => d.Origen)
                    .HasConstraintName("FK_origen");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__DF3D4252F00698C9");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_usuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuarios>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_id_usuario");
            });

            modelBuilder.Entity<Viajes>(entity =>
            {
                entity.HasKey(e => e.IdViajes)
                    .HasName("PK__VIAJES__4831D82036FB2738");

                entity.ToTable("VIAJES");

                entity.Property(e => e.IdViajes).HasColumnName("ID_Viajes");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.HoraSalida).HasColumnName("Hora_salida");

                entity.Property(e => e.IdAutobus).HasColumnName("ID_Autobus");

                entity.Property(e => e.IdChofer).HasColumnName("ID_Chofer");

                entity.Property(e => e.IdRuta).HasColumnName("ID_Ruta");

                entity.HasOne(d => d.IdAutobusNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdAutobus)
                    .HasConstraintName("FK_id_autobus");

                entity.HasOne(d => d.IdChoferNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdChofer)
                    .HasConstraintName("FK_id_chofer");

                entity.HasOne(d => d.IdRutaNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdRuta)
                    .HasConstraintName("FK_id_rutas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
