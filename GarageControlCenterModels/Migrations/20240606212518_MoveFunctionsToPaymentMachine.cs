using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageControlCenterBackend.Migrations
{
    public partial class MoveFunctionsToPaymentMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "UserTickets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "UserTickets");
        }
    }
}
