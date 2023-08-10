using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.VHM20.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesPlacasElementos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesPlacasElementos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPersonas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPersonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPlacas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPlacas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sello = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposVehiculos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TipoPlacaId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposVehiculos_TiposPlacas_TipoPlacaId",
                        column: x => x.TipoPlacaId,
                        principalSchema: "dbo",
                        principalTable: "TiposPlacas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Placas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Placas_TiposVehiculos_TipoVehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalSchema: "dbo",
                        principalTable: "TiposVehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroChasis = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Ano = table.Column<short>(type: "smallint", nullable: false),
                    PlacaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Placas_PlacaId",
                        column: x => x.PlacaId,
                        principalSchema: "dbo",
                        principalTable: "Placas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesPlacas",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TipoPersonaId = table.Column<int>(type: "int", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    TipoVehiculoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesPlacas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesPlacas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "dbo",
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudesPlacas_TiposPersonas_TipoPersonaId",
                        column: x => x.TipoPersonaId,
                        principalSchema: "dbo",
                        principalTable: "TiposPersonas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudesPlacas_TiposVehiculos_TipoVehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalSchema: "dbo",
                        principalTable: "TiposVehiculos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudesPlacas_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalSchema: "dbo",
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Clientes",
                columns: new[] { "Id", "Apellido", "DocumentoIdentidad", "FechaNacimiento", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perez", "00100000012", new DateTime(2000, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro" },
                    { 2, "De Freites", "02301074528", new DateTime(1980, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jason" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TiposPersonas",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Persona Física" },
                    { 2, "Persona Jurídica" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TiposPlacas",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Placas Corrientes" },
                    { 2, "Placas exoneradas" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Usuarios",
                columns: new[] { "Id", "Contrasena", "NombreUsuario", "Sello" },
                values: new object[] { 1, "BFBC2D26CC181F15939DFDA492B46FE11BADFA07AEE71DAE293A14B212D4336D", "admin", "A01EEE8AB9053AD7EC50A5ED9370ABFC619B554E5BBA0FB5BCC25F26B39B52FD" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TiposVehiculos",
                columns: new[] { "Id", "Descripcion", "Letra", "TipoPlacaId", "Valor" },
                values: new object[,]
                {
                    { 1, "Publico", "A", 1, 2500m },
                    { 2, "Privado", "F", 1, 3500m },
                    { 3, "Transporte", "T", 1, 2500m },
                    { 4, "Pesado", "P", 1, 5500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Placas_ClienteId",
                schema: "dbo",
                table: "Placas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Placas_TipoVehiculoId",
                schema: "dbo",
                table: "Placas",
                column: "TipoVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesPlacas_ClienteId",
                schema: "dbo",
                table: "SolicitudesPlacas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesPlacas_TipoPersonaId",
                schema: "dbo",
                table: "SolicitudesPlacas",
                column: "TipoPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesPlacas_TipoVehiculoId",
                schema: "dbo",
                table: "SolicitudesPlacas",
                column: "TipoVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesPlacas_VehiculoId",
                schema: "dbo",
                table: "SolicitudesPlacas",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposVehiculos_TipoPlacaId",
                schema: "dbo",
                table: "TiposVehiculos",
                column: "TipoPlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario",
                schema: "dbo",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_NumeroChasis",
                schema: "dbo",
                table: "Vehiculos",
                column: "NumeroChasis",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_PlacaId",
                schema: "dbo",
                table: "Vehiculos",
                column: "PlacaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudesPlacas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SolicitudesPlacasElementos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TiposPersonas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vehiculos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Placas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TiposVehiculos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TiposPlacas",
                schema: "dbo");
        }
    }
}
