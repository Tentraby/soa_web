using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class _220620233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEmpleado",
                table: "Activos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activos_IdEmpleado",
                table: "Activos",
                column: "IdEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Activos_Personas_IdEmpleado",
                table: "Activos",
                column: "IdEmpleado",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activos_Personas_IdEmpleado",
                table: "Activos");

            migrationBuilder.DropIndex(
                name: "IX_Activos_IdEmpleado",
                table: "Activos");

            migrationBuilder.DropColumn(
                name: "IdEmpleado",
                table: "Activos");
        }
    }
}
