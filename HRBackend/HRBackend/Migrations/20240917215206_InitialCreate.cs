using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HRBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    PuestoAspira = table.Column<string>(type: "text", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    SalarioAspira = table.Column<decimal>(type: "numeric", nullable: false),
                    PrincipalesCompetencias = table.Column<string>(type: "text", nullable: false),
                    PrincipalesCapacitaciones = table.Column<string>(type: "text", nullable: false),
                    RecomendadoPor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capacitacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Nivel = table.Column<string>(type: "text", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Institucion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitacions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cedula = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Puesto = table.Column<string>(type: "text", nullable: false),
                    SalarioMensual = table.Column<decimal>(type: "numeric", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    NivelRiesgo = table.Column<string>(type: "text", nullable: false),
                    NivelMinimoSalario = table.Column<decimal>(type: "numeric", nullable: false),
                    NivelMaximoSalario = table.Column<decimal>(type: "numeric", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienciaLaborals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empresa = table.Column<string>(type: "text", nullable: false),
                    PuestoOcupado = table.Column<string>(type: "text", nullable: false),
                    FechaDesde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Salario = table.Column<decimal>(type: "numeric", nullable: false),
                    CandidatoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienciaLaborals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienciaLaborals_Candidatos_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidatos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciaLaborals_CandidatoId",
                table: "ExperienciaLaborals",
                column: "CandidatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacitacions");

            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "ExperienciaLaborals");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Candidatos");
        }
    }
}
