using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedPatientModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOfDeath",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "HouseNumber",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HouseNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOfDeath",
                table: "Patients",
                type: "datetime2",
                nullable: true);
        }
    }
}
