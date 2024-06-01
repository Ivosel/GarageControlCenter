using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageControlCenterBackend.Migrations
{
    public partial class AddTicketID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Users",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Users");
        }
    }
}
