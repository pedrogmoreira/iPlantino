using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrateAzure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "authentication");

            migrationBuilder.CreateTable(
                name: "tbl_group",
                schema: "authentication",
                columns: table => new
                {
                    id_group = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    inclusion_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    observation = table.Column<string>(type: "varchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_group", x => x.id_group);
                });

            migrationBuilder.CreateTable(
                name: "tbl_permission",
                schema: "authentication",
                columns: table => new
                {
                    id_permission = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    inclusion_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_permission", x => x.id_permission);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                schema: "authentication",
                columns: table => new
                {
                    id_user = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    inclusion_date = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    name = table.Column<string>(type: "varchar(256)", nullable: false),
                    login = table.Column<string>(type: "varchar(20)", nullable: false),
                    hash = table.Column<string>(type: "varchar(100)", nullable: false),
                    deleted = table.Column<DateTime>(type: "date", nullable: true),
                    telephone = table.Column<string>(type: "varchar(15)", nullable: true),
                    email = table.Column<string>(type: "varchar(512)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "tbl_permission_group",
                schema: "authentication",
                columns: table => new
                {
                    id_permission = table.Column<Guid>(nullable: false),
                    id_group = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_permission_group", x => new { x.id_group, x.id_permission });
                    table.ForeignKey(
                        name: "fk_permission_group_group",
                        column: x => x.id_group,
                        principalSchema: "authentication",
                        principalTable: "tbl_group",
                        principalColumn: "id_group",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_permission_group_permission",
                        column: x => x.id_permission,
                        principalSchema: "authentication",
                        principalTable: "tbl_permission",
                        principalColumn: "id_permission",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_group",
                schema: "authentication",
                columns: table => new
                {
                    id_group = table.Column<Guid>(nullable: false),
                    id_user = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_group", x => new { x.id_group, x.id_user });
                    table.ForeignKey(
                        name: "fk_user_group_group",
                        column: x => x.id_group,
                        principalSchema: "authentication",
                        principalTable: "tbl_group",
                        principalColumn: "id_group",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_group_user",
                        column: x => x.id_user,
                        principalSchema: "authentication",
                        principalTable: "tbl_user",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_permission_group_id_permission",
                schema: "authentication",
                table: "tbl_permission_group",
                column: "id_permission");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_group_id_user",
                schema: "authentication",
                table: "tbl_user_group",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_permission_group",
                schema: "authentication");

            migrationBuilder.DropTable(
                name: "tbl_user_group",
                schema: "authentication");

            migrationBuilder.DropTable(
                name: "tbl_permission",
                schema: "authentication");

            migrationBuilder.DropTable(
                name: "tbl_group",
                schema: "authentication");

            migrationBuilder.DropTable(
                name: "tbl_user",
                schema: "authentication");
        }
    }
}
