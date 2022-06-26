using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseProject.DataAccess.Migrations
{
    public partial class DatabaseInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "case");

            migrationBuilder.CreateTable(
                name: "Words",
                schema: "case",
                columns: table => new
                {
                    Value = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseProject_Words", x => x.Value);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words",
                schema: "case");
        }
    }
}
