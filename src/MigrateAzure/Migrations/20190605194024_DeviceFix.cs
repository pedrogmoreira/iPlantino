using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrateAzure.Migrations
{
    public partial class DeviceFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mac_address",
                schema: "device",
                table: "arduino",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mac_address",
                schema: "device",
                table: "arduino");
        }
    }
}
