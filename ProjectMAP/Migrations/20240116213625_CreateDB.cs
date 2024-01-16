using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMAP.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnostic",
                columns: table => new
                {
                    DiagnosticID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiagnosticName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostic", x => x.DiagnosticID);
                });

            migrationBuilder.CreateTable(
                name: "Pacient",
                columns: table => new
                {
                    PacientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInsured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacient", x => x.PacientID);
                });

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    SpecialtyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.SpecialtyID);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialty_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Specialty",
                        principalColumn: "SpecialtyID");
                });

            migrationBuilder.CreateTable(
                name: "MedicalImage",
                columns: table => new
                {
                    MedicalImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiagnosticID = table.Column<int>(type: "int", nullable: true),
                    PacientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalImage", x => x.MedicalImageID);
                    table.ForeignKey(
                        name: "FK_MedicalImage_Diagnostic_DiagnosticID",
                        column: x => x.DiagnosticID,
                        principalTable: "Diagnostic",
                        principalColumn: "DiagnosticID");
                    table.ForeignKey(
                        name: "FK_MedicalImage_Doctor_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctor",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalImage_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "PacientID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecialtyID",
                table: "Doctor",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalImage_DiagnosticID",
                table: "MedicalImage",
                column: "DiagnosticID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalImage_DoctorID",
                table: "MedicalImage",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalImage_PacientID",
                table: "MedicalImage",
                column: "PacientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalImage");

            migrationBuilder.DropTable(
                name: "Diagnostic");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Pacient");

            migrationBuilder.DropTable(
                name: "Specialty");
        }
    }
}
