using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageControlCenterBackend.Migrations
{
    public partial class FinalTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
