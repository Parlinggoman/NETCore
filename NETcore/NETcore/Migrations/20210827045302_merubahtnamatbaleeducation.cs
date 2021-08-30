using Microsoft.EntityFrameworkCore.Migrations;

namespace NETcore.Migrations
{
    public partial class merubahtnamatbaleeducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb-tr-Persons_tb-m-University_UniversityId",
                table: "tb-tr-Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_tb-tr-Profiling_tb-tr-Persons_EducationId",
                table: "tb-tr-Profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb-tr-Persons",
                table: "tb-tr-Persons");

            migrationBuilder.RenameTable(
                name: "tb-tr-Persons",
                newName: "tb-tr-Education");

            migrationBuilder.RenameIndex(
                name: "IX_tb-tr-Persons_UniversityId",
                table: "tb-tr-Education",
                newName: "IX_tb-tr-Education_UniversityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb-tr-Education",
                table: "tb-tr-Education",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb-tr-Education_tb-m-University_UniversityId",
                table: "tb-tr-Education",
                column: "UniversityId",
                principalTable: "tb-m-University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb-tr-Profiling_tb-tr-Education_EducationId",
                table: "tb-tr-Profiling",
                column: "EducationId",
                principalTable: "tb-tr-Education",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb-tr-Education_tb-m-University_UniversityId",
                table: "tb-tr-Education");

            migrationBuilder.DropForeignKey(
                name: "FK_tb-tr-Profiling_tb-tr-Education_EducationId",
                table: "tb-tr-Profiling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb-tr-Education",
                table: "tb-tr-Education");

            migrationBuilder.RenameTable(
                name: "tb-tr-Education",
                newName: "tb-tr-Persons");

            migrationBuilder.RenameIndex(
                name: "IX_tb-tr-Education_UniversityId",
                table: "tb-tr-Persons",
                newName: "IX_tb-tr-Persons_UniversityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb-tr-Persons",
                table: "tb-tr-Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb-tr-Persons_tb-m-University_UniversityId",
                table: "tb-tr-Persons",
                column: "UniversityId",
                principalTable: "tb-m-University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb-tr-Profiling_tb-tr-Persons_EducationId",
                table: "tb-tr-Profiling",
                column: "EducationId",
                principalTable: "tb-tr-Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
