using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRBackend.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienciaLaborals_Candidatos_CandidatoId",
                table: "ExperienciaLaborals");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienciaLaborals_Candidatos_CandidatoId",
                table: "ExperienciaLaborals",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperienciaLaborals_Candidatos_CandidatoId",
                table: "ExperienciaLaborals");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienciaLaborals_Candidatos_CandidatoId",
                table: "ExperienciaLaborals",
                column: "CandidatoId",
                principalTable: "Candidatos",
                principalColumn: "Id");
        }
    }
}
