using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageControlCenterBackend.Migrations
{
    public partial class TicketUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TicketNumber",
                table: "Tickets",
                newName: "RegistrationPlate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegistrationPlate",
                table: "Tickets",
                newName: "TicketNumber");
        }
    }
}
