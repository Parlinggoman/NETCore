using Microsoft.EntityFrameworkCore.Migrations;

namespace NETcore.Migrations
{
    public partial class updateroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gender",
                table: "tb-m-Persons",
                newName: "GenderName");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "tb-m-Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "tb-m-Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb-m-Account_RoleId",
                table: "tb-m-Account",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb-m-Account_tb_m_roles_RoleId",
                table: "tb-m-Account",
                column: "RoleId",
                principalTable: "tb_m_roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb-m-Account_tb_m_roles_RoleId",
                table: "tb-m-Account");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb-m-Account_RoleId",
                table: "tb-m-Account");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "tb-m-Account");

            migrationBuilder.RenameColumn(
                name: "GenderName",
                table: "tb-m-Persons",
                newName: "gender");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "tb-m-Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
