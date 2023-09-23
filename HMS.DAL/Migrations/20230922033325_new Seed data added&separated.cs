using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class newSeeddataaddedseparated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "WardCabins",
                keyColumn: "WardID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "WasteType",
                table: "WasteManagements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "DepartmentID", "DoctorName", "Doctortype", "Education_Info", "Image", "JoinDate", "ResignDate", "Specialization", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Pipul Rahman", 1, "MD in Cardiology from DMC University", "doctor1.jpg", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cardiologist", 1 },
                    { 2, 2, "Ass Pina", 4, "MD in Orthopedics from ABC University", "doctor2.jpg", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Orthopedic Surgeon", 1 }
                });

            migrationBuilder.InsertData(
                table: "LabTechnicians",
                columns: new[] { "TechnicianID", "DepartmentID", "Education_Info", "Image", "JoinDate", "ResignDate", "TechnicianName", "TechnicianType", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Bachelor of Science in Medical Technology", "labtech1.jpg", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "valsun choudhury", 1, 1 },
                    { 2, 2, "Certified Laboratory Technician", "labtech2.jpg", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robin mia", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "NurseID", "DepartmentID", "Education_Info", "Image", "JoinDate", "NurseLevel", "NurseName", "NurseType", "ResignDate", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Bachelor of Science in Nursing", "nurse1.jpg", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sharmin Jahan", 1, null, 1 },
                    { 2, 2, "Licensed Practical Nurse Certification", "nurse2.jpg", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Hafsa khatun", 2, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "OtherEmployees",
                columns: new[] { "EmployeeID", "Education_Info", "Image", "JoinDate", "OtherEmployeeName", "OtherEmployeeType", "ResignDate", "employeeStatus" },
                values: new object[,]
                {
                    { 1, "JSC", "wordboy1.jpg", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "abul mia", 2, null, 1 },
                    { 2, "SSC", "driver1.jpg", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ataur", 6, null, 2 }
                });

            migrationBuilder.UpdateData(
                table: "PatientRegisters",
                keyColumn: "PatientID",
                keyValue: 1,
                columns: new[] { "IsTransferred", "PatientName" },
                values: new object[] { true, "Sultana begum" });

            migrationBuilder.UpdateData(
                table: "PatientRegisters",
                keyColumn: "PatientID",
                keyValue: 2,
                columns: new[] { "Address", "WardID" },
                values: new object[] { "Sirajgonj", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LabTechnicians",
                keyColumn: "TechnicianID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LabTechnicians",
                keyColumn: "TechnicianID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "NurseID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nurses",
                keyColumn: "NurseID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OtherEmployees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OtherEmployees",
                keyColumn: "EmployeeID",
                keyValue: 2);

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

            migrationBuilder.AddColumn<int>(
                name: "PatientRegisterPatientID",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PatientRegisters",
                keyColumn: "PatientID",
                keyValue: 1,
                columns: new[] { "IsTransferred", "PatientName" },
                values: new object[] { false, "amina begum" });

            migrationBuilder.UpdateData(
                table: "PatientRegisters",
                keyColumn: "PatientID",
                keyValue: 2,
                columns: new[] { "Address", "WardID" },
                values: new object[] { "Pabna", 3 });

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
    }
}
