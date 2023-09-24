using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class sp_ataur : Migration
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
                name: "DriverName",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "DrivingLiense",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Ambulances");

            migrationBuilder.RenameColumn(
                name: "PatientRegisterPatientID",
                table: "Prescriptions",
                newName: "SymptomId");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions",
                newName: "IX_Prescriptions_SymptomId");

            migrationBuilder.AddColumn<int>(
                name: "AdviceId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmbulanceID",
                table: "OtherEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "OtherEmployees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "LabTechnicians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastLocation",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "Advices",
                columns: table => new
                {
                    AdviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdviceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advices", x => x.AdviceId);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    SymptomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymptomName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.SymptomId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AdviceId",
                table: "Prescriptions",
                column: "AdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherEmployees_AmbulanceID",
                table: "OtherEmployees",
                column: "AmbulanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherEmployees_Ambulances_AmbulanceID",
                table: "OtherEmployees",
                column: "AmbulanceID",
                principalTable: "Ambulances",
                principalColumn: "AmbulanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Advices_AdviceId",
                table: "Prescriptions",
                column: "AdviceId",
                principalTable: "Advices",
                principalColumn: "AdviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Symptoms_SymptomId",
                table: "Prescriptions",
                column: "SymptomId",
                principalTable: "Symptoms",
                principalColumn: "SymptomId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Cascade);
            string getall = @"create proc SpAllAmbulances
              as
              BEGIN
              SELECT * FROM Ambulances
              END";
            string getbyid = @"create proc SpAmbulancesgetById(@id int)
            as
            BEGIN
            SELECT * FROM Ambulances where AmbulanceID=@id 
            END";
            string InsertAmbulance = @"
            CREATE PROCEDURE InsertAmbulance
                @AmbulanceNumber NVARCHAR(10),
              
                @LastLocation NVARCHAR(200),
                @Availability BIT
            AS
            BEGIN
                INSERT INTO Ambulances (AmbulanceNumber,LastLocation, Availability)
                VALUES (@AmbulanceNumber, @LastLocation, @Availability);
            END";
            string UpdateAmbulance = @"
            CREATE PROCEDURE UpdateAmbulance
                @AmbulanceID INT,
                @AmbulanceNumber NVARCHAR(10),
            
                @LastLocation NVARCHAR(200),
                @Availability BIT
            AS
            BEGIN
                UPDATE Ambulances
                SET AmbulanceNumber = @AmbulanceNumber,
                    LastLocation = @LastLocation,
                    Availability = @Availability
                WHERE AmbulanceID = @AmbulanceID;
            END";
            string DeleteAmbulance = @"
            CREATE PROCEDURE DeleteAmbulance
                @AmbulanceID INT
            AS
            BEGIN
                DELETE FROM Ambulances
                WHERE AmbulanceID = @AmbulanceID;
            END";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertAmbulance);
            migrationBuilder.Sql(UpdateAmbulance);
            migrationBuilder.Sql(DeleteAmbulance);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherEmployees_Ambulances_AmbulanceID",
                table: "OtherEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Advices_AdviceId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Symptoms_SymptomId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropTable(
                name: "Advices");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AdviceId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_OtherEmployees_AmbulanceID",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "AdviceId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "AmbulanceID",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "LabTechnicians");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "SymptomId",
                table: "Prescriptions",
                newName: "PatientRegisterPatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_SymptomId",
                table: "Prescriptions",
                newName: "IX_Prescriptions_PatientRegisterPatientID");

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastLocation",
                table: "Ambulances",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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


            string getall = @"Drop proc SpAllAmbulances";
            string getbyid = @"Drop proc SpAmbulancesgetById";
            string InsertAmbulance = @"Drop proc InsertAmbulance";
            string UpdateAmbulance = @"Drop proc UpdateAmbulance";
            string DeleteAmbulance = @"Drop proc DeleteAmbulance";


            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertAmbulance);
            migrationBuilder.Sql(UpdateAmbulance);
            migrationBuilder.Sql(DeleteAmbulance);
        }
    }
}
