using Microsoft.EntityFrameworkCore.Migrations;

namespace NETcore.Migrations
{
    public partial class updateterbaru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb-tr-Profiling",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb-tr-Profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb-tr-Profiling_tb-m-Account_NIK",
                        column: x => x.NIK,
                        principalTable: "tb-m-Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb-tr-Profiling_tb-tr-Persons_EducationId",
                        column: x => x.EducationId,
                        principalTable: "tb-tr-Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb-tr-Persons_UniversityId",
                table: "tb-tr-Persons",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb-tr-Profiling_EducationId",
                table: "tb-tr-Profiling",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb-m-Account_tb-m-Persons_NIK",
                table: "tb-m-Account",
                column: "NIK",
                principalTable: "tb-m-Persons",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb-tr-Persons_tb-m-University_UniversityId",
                table: "tb-tr-Persons",
                column: "UniversityId",
                principalTable: "tb-m-University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb-m-Account_tb-m-Persons_NIK",
                table: "tb-m-Account");

            migrationBuilder.DropForeignKey(
                name: "FK_tb-tr-Persons_tb-m-University_UniversityId",
                table: "tb-tr-Persons");

            migrationBuilder.DropTable(
                name: "tb-tr-Profiling");

            migrationBuilder.DropIndex(
                name: "IX_tb-tr-Persons_UniversityId",
                table: "tb-tr-Persons");
        }
    }
}
