using Microsoft.EntityFrameworkCore.Migrations;

namespace NETcore.Migrations
{
    public partial class uahnamatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "tb-m-Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb-m-Persons",
                table: "tb-m-Persons",
                column: "NIK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb-m-Persons",
                table: "tb-m-Persons");

            migrationBuilder.RenameTable(
                name: "tb-m-Persons",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "NIK");
        }
    }
}
