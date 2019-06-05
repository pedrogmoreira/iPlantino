using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrateAzure.Migrations
{
    public partial class Device : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "device");

            migrationBuilder.CreateTable(
                name: "arduino",
                schema: "device",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    inclusion_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    name = table.Column<string>(maxLength: 256, nullable: false),
                    observation = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arduino", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "humidity",
                schema: "device",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    inclusion_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    measurement = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_humidity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "arduino_has_humidity",
                schema: "device",
                columns: table => new
                {
                    arduino_id = table.Column<Guid>(nullable: false),
                    humidity_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arduino_has_humidity", x => new { x.arduino_id, x.humidity_id });
                    table.ForeignKey(
                        name: "FK_arduino_has_humidity_arduino_arduino_id",
                        column: x => x.arduino_id,
                        principalSchema: "device",
                        principalTable: "arduino",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_arduino_has_humidity_humidity_humidity_id",
                        column: x => x.humidity_id,
                        principalSchema: "device",
                        principalTable: "humidity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "arduino_has_humidity_id_index",
                schema: "device",
                table: "arduino_has_humidity",
                column: "arduino_id");

            migrationBuilder.CreateIndex(
                name: "IX_arduino_has_humidity_humidity_id",
                schema: "device",
                table: "arduino_has_humidity",
                column: "humidity_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arduino_has_humidity",
                schema: "device");

            migrationBuilder.DropTable(
                name: "arduino",
                schema: "device");

            migrationBuilder.DropTable(
                name: "humidity",
                schema: "device");
        }
    }
}
