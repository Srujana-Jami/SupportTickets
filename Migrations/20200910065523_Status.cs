using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportPagesPro.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Assigned",
                table: "SupportTicket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SupportTicket",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assigned",
                table: "SupportTicket");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SupportTicket");
        }
    }
}
