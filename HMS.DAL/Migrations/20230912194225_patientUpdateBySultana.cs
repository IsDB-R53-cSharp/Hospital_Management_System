using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class patientUpdateBySultana : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PatientRegisters_PatientID",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_DischargeTransfers_PatientRegisters_PatientID",
                table: "DischargeTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_LabTests_PatientRegisters_PatientID",
                table: "LabTests");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_PatientRegisters_PatientID",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRegisters_WardCabins_WardID",
                table: "PatientRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_PatientRegisters_PatientID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_PatientRegisters_PatientID",
                table: "SurgeryProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_SurgeryProcedures_PatientID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_PatientRegisters_WardID",
                table: "PatientRegisters");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PatientID",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_LabTests_PatientID",
                table: "LabTests");

            migrationBuilder.DropIndex(
                name: "IX_DischargeTransfers_PatientID",
                table: "DischargeTransfers");

            migrationBuilder.DropIndex(
                name: "IX_Bills_PatientID",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "SurgeryProcedures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PatientRegisterPatientID",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "MedicalRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "LabTests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "DischargeTransfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Bills",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentDescription", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "It is concerned with disorders and diseases of the nervous system", "Neurology" },
                    { 2, "The branch of medicine dealing with children and their diseases.", "Paediatrics" }
                });

            migrationBuilder.InsertData(
                table: "PatientRegisters",
                columns: new[] { "PatientID", "Address", "AdmissionDate", "BloodType", "DateOfBirth", "Email", "EmergencyContact", "Gender", "IsTransferred", "PatientName", "PhoneNumber", "WardID" },
                values: new object[,]
                {
                    { 1, "dhaka", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1999, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "am@gmail.com", "123456789", 2, false, "amina begum", "12345678", 1 },
                    { 2, "Pabna", new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(1971, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "az@gmail.com", "123456789", 1, false, "Azman Mollah", "1233454", 3 }
                });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "BedCabinNumber", "DepartmentID", "WardName" },
                values: new object[] { 1, 23, 1, "Neuro Care" });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "BedCabinNumber", "DepartmentID", "WardName" },
                values: new object[] { 2, 40, 2, "Child Care" });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "BedCabinNumber", "DepartmentID", "WardName" },
                values: new object[] { 3, 12, 1, "Nerve Care" });

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionsPrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions",
                column: "PatientRegisterPatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_PatientRegisters_PatientRegisterPatientID",
                table: "Prescriptions",
                column: "PatientRegisterPatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionsPrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_PatientRegisters_PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.DeleteData(
                table: "PatientRegisters",
                keyColumn: "PatientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PatientRegisters",
                keyColumn: "PatientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WardCabins",
                keyColumn: "WardID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WardCabins",
                keyColumn: "WardID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WardCabins",
                keyColumn: "WardID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "SurgeryProcedures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "MedicalRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "LabTests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "DischargeTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_PatientID",
                table: "SurgeryProcedures",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientID",
                table: "Prescriptions",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRegisters_WardID",
                table: "PatientRegisters",
                column: "WardID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientID",
                table: "MedicalRecords",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_PatientID",
                table: "LabTests",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DischargeTransfers_PatientID",
                table: "DischargeTransfers",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PatientID",
                table: "Bills",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PatientRegisters_PatientID",
                table: "Bills",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DischargeTransfers_PatientRegisters_PatientID",
                table: "DischargeTransfers",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LabTests_PatientRegisters_PatientID",
                table: "LabTests",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_PatientRegisters_PatientID",
                table: "MedicalRecords",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRegisters_WardCabins_WardID",
                table: "PatientRegisters",
                column: "WardID",
                principalTable: "WardCabins",
                principalColumn: "WardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_PatientRegisters_PatientID",
                table: "Prescriptions",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_PatientRegisters_PatientID",
                table: "SurgeryProcedures",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
