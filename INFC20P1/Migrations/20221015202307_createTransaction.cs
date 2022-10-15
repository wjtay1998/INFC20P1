using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INFC20P1.Migrations
{
    public partial class createTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trans",
                columns: table => new
                {
                    tid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    send_id = table.Column<int>(type: "int", nullable: false),
                    recieve_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    t_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans", x => x.tid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trans");
        }
    }
}
