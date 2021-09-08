using Microsoft.EntityFrameworkCore.Migrations;

namespace NETcore.Migrations
{
    public partial class migrasibaruu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_accountroles_tb-m-Account_AccountNIK",
                table: "tb_tr_accountroles");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_accountroles_AccountNIK",
                table: "tb_tr_accountroles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "tb-m-Account");

            migrationBuilder.DropColumn(
                name: "AccountNIK",
                table: "tb_tr_accountroles");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_accountroles_tb-m-Account_NIK",
                table: "tb_tr_accountroles",
                column: "NIK",
                principalTable: "tb-m-Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_accountroles_tb-m-Account_NIK",
                table: "tb_tr_accountroles");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "tb-m-Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AccountNIK",
                table: "tb_tr_accountroles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountroles_AccountNIK",
                table: "tb_tr_accountroles",
                column: "AccountNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_accountroles_tb-m-Account_AccountNIK",
                table: "tb_tr_accountroles",
                column: "AccountNIK",
                principalTable: "tb-m-Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
