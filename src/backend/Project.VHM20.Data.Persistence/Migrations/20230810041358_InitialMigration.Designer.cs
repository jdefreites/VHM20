﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.VHM20.Data.Persistence;

#nullable disable

namespace Project.VHM20.Data.Persistence.Migrations
{
    [DbContext(typeof(VhmDbContext))]
    [Migration("20230810041358_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.VHM20.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("DocumentoIdentidad")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Perez",
                            DocumentoIdentidad = "00100000012",
                            FechaNacimiento = new DateTime(2000, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Pedro"
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "De Freites",
                            DocumentoIdentidad = "02301074528",
                            FechaNacimiento = new DateTime(1980, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Jason"
                        });
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Placa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoVehiculoId");

                    b.ToTable("Placas", "dbo");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.SolicitudPlaca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("TipoPersonaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoPersonaId");

                    b.HasIndex("TipoVehiculoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("SolicitudesPlacas", "dbo");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.SolicitudPlacaElemento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TipoVehiculoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SolicitudesPlacasElementos", "dbo");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TiposPersonas", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Persona Física"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Persona Jurídica"
                        });
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.TipoPlaca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TiposPlacas", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Placas Corrientes"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Placas exoneradas"
                        });
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.TipoVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Letra")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("TipoPlacaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TipoPlacaId");

                    b.ToTable("TiposVehiculos", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Publico",
                            Letra = "A",
                            TipoPlacaId = 1,
                            Valor = 2500m
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Privado",
                            Letra = "F",
                            TipoPlacaId = 1,
                            Valor = 3500m
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Transporte",
                            Letra = "T",
                            TipoPlacaId = 1,
                            Valor = 2500m
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Pesado",
                            Letra = "P",
                            TipoPlacaId = 1,
                            Valor = 5500m
                        });
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Sello")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NombreUsuario")
                        .IsUnique();

                    b.ToTable("Usuarios", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contrasena = "BFBC2D26CC181F15939DFDA492B46FE11BADFA07AEE71DAE293A14B212D4336D",
                            NombreUsuario = "admin",
                            Sello = "A01EEE8AB9053AD7EC50A5ED9370ABFC619B554E5BBA0FB5BCC25F26B39B52FD"
                        });
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("Ano")
                        .HasColumnType("smallint");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("NumeroChasis")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("PlacaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NumeroChasis")
                        .IsUnique();

                    b.HasIndex("PlacaId")
                        .IsUnique();

                    b.ToTable("Vehiculos", "dbo");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Placa", b =>
                {
                    b.HasOne("Project.VHM20.Data.Entities.Cliente", "Cliente")
                        .WithMany("Placas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.VHM20.Data.Entities.TipoVehiculo", "TipoVehiculo")
                        .WithMany("Placas")
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoVehiculo");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.SolicitudPlaca", b =>
                {
                    b.HasOne("Project.VHM20.Data.Entities.Cliente", "Cliente")
                        .WithMany("Solicitudes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.VHM20.Data.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Solicitudes")
                        .HasForeignKey("TipoPersonaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.VHM20.Data.Entities.TipoVehiculo", "TipoVehiculo")
                        .WithMany("Solicitudes")
                        .HasForeignKey("TipoVehiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.VHM20.Data.Entities.Vehiculo", "Vehiculo")
                        .WithMany("Solicitudes")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TipoPersona");

                    b.Navigation("TipoVehiculo");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.TipoVehiculo", b =>
                {
                    b.HasOne("Project.VHM20.Data.Entities.TipoPlaca", "TipoPlaca")
                        .WithMany("TiposVehiculos")
                        .HasForeignKey("TipoPlacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPlaca");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Vehiculo", b =>
                {
                    b.HasOne("Project.VHM20.Data.Entities.Placa", "Placa")
                        .WithOne("Vehiculo")
                        .HasForeignKey("Project.VHM20.Data.Entities.Vehiculo", "PlacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Placa");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Cliente", b =>
                {
                    b.Navigation("Placas");

                    b.Navigation("Solicitudes");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Placa", b =>
                {
                    b.Navigation("Vehiculo")
                        .IsRequired();
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.TipoPersona", b =>
                {
                    b.Navigation("Solicitudes");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.TipoPlaca", b =>
                {
                    b.Navigation("TiposVehiculos");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.TipoVehiculo", b =>
                {
                    b.Navigation("Placas");

                    b.Navigation("Solicitudes");
                });

            modelBuilder.Entity("Project.VHM20.Data.Entities.Vehiculo", b =>
                {
                    b.Navigation("Solicitudes");
                });
#pragma warning restore 612, 618
        }
    }
}
