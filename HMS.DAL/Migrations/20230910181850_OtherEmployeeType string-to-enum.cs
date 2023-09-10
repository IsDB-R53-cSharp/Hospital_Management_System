using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class OtherEmployeeTypestringtoenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Outdoors_PatientRegisters_PatientID",
                table: "Outdoors");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ProcedureType",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "GenericName",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "SellQuantity",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "doctortype",
                table: "Doctors",
                newName: "Doctortype");

            migrationBuilder.AlterColumn<string>(
                name: "WardName",
                table: "WardCabins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SurgeryDate",
                table: "SurgeryProcedures",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Preoperative_Diagnosis",
                table: "SurgeryProcedures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Postoperative_Diagnosis",
                table: "SurgeryProcedures",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "SurgeryProcedures",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NurseID",
                table: "SurgeryProcedures",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurgeryType",
                table: "SurgeryProcedures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NurseID",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TreatmentDate",
                table: "Outdoors",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Outdoors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "OtherEmployees",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OtherEmployeeType",
                table: "OtherEmployees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OtherEmployeeName",
                table: "OtherEmployees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "OtherEmployees",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "OtherEmployees",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "Nurses",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NurseName",
                table: "Nurses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Nurses",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "Nurses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerID",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicineGenericID",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianType",
                table: "LabTechnicians",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianName",
                table: "LabTechnicians",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "LabTechnicians",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "LabTechnicians",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "LabTechnicians",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Doctors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "Doctors",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Doctors",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "Doctors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "Doctors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NurseID",
                table: "Appointments",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineGeneric",
                columns: table => new
                {
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineGenericNames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineGeneric", x => x.MedicineGenericID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_NurseID",
                table: "SurgeryProcedures",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_NurseID",
                table: "Prescriptions",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ManufacturerID",
                table: "Medicines",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineGenericID",
                table: "Medicines",
                column: "MedicineGenericID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTechnicians_DepartmentID",
                table: "LabTechnicians",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_NurseID",
                table: "Appointments",
                column: "NurseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Nurses_NurseID",
                table: "Appointments",
                column: "NurseID",
                principalTable: "Nurses",
                principalColumn: "NurseID");

            migrationBuilder.AddForeignKey(
                name: "FK_LabTechnicians_Departments_DepartmentID",
                table: "LabTechnicians",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Manufacturer_ManufacturerID",
                table: "Medicines",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ManufacturerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineGeneric_MedicineGenericID",
                table: "Medicines",
                column: "MedicineGenericID",
                principalTable: "MedicineGeneric",
                principalColumn: "MedicineGenericID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Outdoors_PatientRegisters_PatientID",
                table: "Outdoors",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Nurses_NurseID",
                table: "Prescriptions",
                column: "NurseID",
                principalTable: "Nurses",
                principalColumn: "NurseID");

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Nurses_NurseID",
                table: "SurgeryProcedures",
                column: "NurseID",
                principalTable: "Nurses",
                principalColumn: "NurseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Nurses_NurseID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_LabTechnicians_Departments_DepartmentID",
                table: "LabTechnicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Manufacturer_ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineGeneric_MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Outdoors_PatientRegisters_PatientID",
                table: "Outdoors");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Nurses_NurseID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Nurses_NurseID",
                table: "SurgeryProcedures");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "MedicineGeneric");

            migrationBuilder.DropIndex(
                name: "IX_SurgeryProcedures_NurseID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_NurseID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_LabTechnicians_DepartmentID",
                table: "LabTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_NurseID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NurseID",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "SurgeryType",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "NurseID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "NurseID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DrivingLiense",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Ambulances");

            migrationBuilder.RenameColumn(
                name: "Doctortype",
                table: "Doctors",
                newName: "doctortype");

            migrationBuilder.AlterColumn<string>(
                name: "WardName",
                table: "WardCabins",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SurgeryDate",
                table: "SurgeryProcedures",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Preoperative_Diagnosis",
                table: "SurgeryProcedures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Postoperative_Diagnosis",
                table: "SurgeryProcedures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "SurgeryProcedures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "ProcedureType",
                table: "SurgeryProcedures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TreatmentDate",
                table: "Outdoors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Outdoors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "OtherEmployees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OtherEmployeeType",
                table: "OtherEmployees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OtherEmployeeName",
                table: "OtherEmployees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "OtherEmployees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "OtherEmployees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "Nurses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NurseName",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Nurses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "GenericName",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SellQuantity",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianType",
                table: "LabTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicianName",
                table: "LabTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "LabTechnicians",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "LabTechnicians",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "LabTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ResignDate",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Education_Info",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Outdoors_PatientRegisters_PatientID",
                table: "Outdoors",
                column: "PatientID",
                principalTable: "PatientRegisters",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
