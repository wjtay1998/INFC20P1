using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFC20P1.Migrations.INFC20P1Person
{
    public partial class updatePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Person",
                newName: "sent");

            migrationBuilder.AddColumn<decimal>(
                name: "recieved",
                table: "Person",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "recieved",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "sent",
                table: "Person",
                newName: "balance");
        }
    }
}
