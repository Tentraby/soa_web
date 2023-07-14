using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class _20230715 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumEmpleado",
                table: "Personas",
                newName: "IdEmpleado");

            migrationBuilder.RenameColumn(
                name: "NumEmpleado",
                table: "Activos_Empleados",
                newName: "IdEmpleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Personas",
                newName: "NumEmpleado");

            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Activos_Empleados",
                newName: "NumEmpleado");
        }
    }
}
