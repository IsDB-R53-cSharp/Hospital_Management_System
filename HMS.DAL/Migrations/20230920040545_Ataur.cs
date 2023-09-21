using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Ataur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Prescriptions_PrescriptionsPrescriptionID",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_LabTests_TestID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_TestID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PrescriptionsPrescriptionID",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "Advice",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DiagonesNotes",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SymptomStartDate",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionsPrescriptionID",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "DrivingLiense",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Ambulances");

            migrationBuilder.RenameColumn(
                name: "Severity",
                table: "Prescriptions",
                newName: "TestsID");

            migrationBuilder.AlterColumn<int>(
                name: "WasteType",
                table: "WasteManagements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AdviceID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LabTestTestID",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SymptomsID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "OtherEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Ambulances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_LabTestTestID",
                table: "Prescriptions",
                column: "LabTestTestID");

            migrationBuilder.CreateIndex(
                name: "IX_Ambulances_EmployeeID",
                table: "Ambulances",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ambulances_OtherEmployees_EmployeeID",
                table: "Ambulances",
                column: "EmployeeID",
                principalTable: "OtherEmployees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_LabTests_LabTestTestID",
                table: "Prescriptions",
                column: "LabTestTestID",
                principalTable: "LabTests",
                principalColumn: "TestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ambulances_OtherEmployees_EmployeeID",
                table: "Ambulances");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_LabTests_LabTestTestID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_LabTestTestID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Ambulances_EmployeeID",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "AdviceID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "LabTestTestID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SymptomsID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Ambulances");

            migrationBuilder.RenameColumn(
                name: "TestsID",
                table: "Prescriptions",
                newName: "Severity");

            migrationBuilder.AlterColumn<string>(
                name: "WasteType",
                table: "WasteManagements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Advice",
                table: "Prescriptions",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiagonesNotes",
                table: "Prescriptions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SymptomStartDate",
                table: "Prescriptions",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Prescriptions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionsPrescriptionID",
                table: "MedicalRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "Ambulances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DrivingLiense",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionsPrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorID",
                table: "Prescriptions",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_TestID",
                table: "Prescriptions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PrescriptionsPrescriptionID",
                table: "MedicalRecords",
                column: "PrescriptionsPrescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Prescriptions_PrescriptionsPrescriptionID",
                table: "MedicalRecords",
                column: "PrescriptionsPrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorID",
                table: "Prescriptions",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_LabTests_TestID",
                table: "Prescriptions",
                column: "TestID",
                principalTable: "LabTests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionsPrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID");
        }
    }
}
