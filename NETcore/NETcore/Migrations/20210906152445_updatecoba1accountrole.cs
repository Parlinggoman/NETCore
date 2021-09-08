using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NETcore.Migrations
{
    public partial class updatecoba1accountrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_reset_passwords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_reset_passwords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tb-m-Persons",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb-m-Persons", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "tb-m-University",
                columns: table => new
                {
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb-m-University", x => x.UniversityId);
                });

            migrationBuilder.CreateTable(
                name: "tb-m-Account",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb-m-Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb-m-Account_tb-m-Persons_NIK",
                        column: x => x.NIK,
                        principalTable: "tb-m-Persons",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb-tr-Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb-tr-Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb-tr-Education_tb-m-University_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "tb-m-University",
                        principalColumn: "UniversityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_accountroles",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_accountroles", x => new { x.NIK, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tb_tr_accountroles_tb_m_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_accountroles_tb-m-Account_AccountNIK",
                        column: x => x.AccountNIK,
                        principalTable: "tb-m-Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        name: "FK_tb-tr-Profiling_tb-tr-Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "tb-tr-Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountroles_AccountNIK",
                table: "tb_tr_accountroles",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_accountroles_RoleId",
                table: "tb_tr_accountroles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tb-tr-Education_UniversityId",
                table: "tb-tr-Education",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb-tr-Profiling_EducationId",
                table: "tb-tr-Profiling",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_reset_passwords");

            migrationBuilder.DropTable(
                name: "tb_tr_accountroles");

            migrationBuilder.DropTable(
                name: "tb-tr-Profiling");

            migrationBuilder.DropTable(
                name: "tb_m_Roles");

            migrationBuilder.DropTable(
                name: "tb-m-Account");

            migrationBuilder.DropTable(
                name: "tb-tr-Education");

            migrationBuilder.DropTable(
                name: "tb-m-Persons");

            migrationBuilder.DropTable(
                name: "tb-m-University");
        }
    }
}
