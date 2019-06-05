using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrateAzure.Migrations
{
    public partial class UserArduino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "device",
                table: "arduino",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "user_arduino",
                schema: "identity",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    arduino_id = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_arduino", x => new { x.user_id, x.arduino_id });
                    table.ForeignKey(
                        name: "FK_user_arduino_arduino_arduino_id",
                        column: x => x.arduino_id,
                        principalSchema: "device",
                        principalTable: "arduino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_arduino_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "identity",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "user_arduino_id_index",
                schema: "identity",
                table: "user_arduino",
                column: "arduino_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_arduino",
                schema: "identity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "device",
                table: "arduino");
        }
    }
}
