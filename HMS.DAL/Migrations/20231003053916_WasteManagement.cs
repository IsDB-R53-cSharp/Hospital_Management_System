using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class WasteManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surgeries_Doctors_DoctorID",
                table: "Surgeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Surgeries_Tests_TestID",
                table: "Surgeries");

            migrationBuilder.DropIndex(
                name: "IX_Surgeries_DoctorID",
                table: "Surgeries");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Surgeries");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Surgeries");

            migrationBuilder.DropColumn(
                name: "Preoperative_Diagnosis",
                table: "Surgeries");

            migrationBuilder.AlterColumn<int>(
                name: "TestID",
                table: "Surgeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Surgeries_Tests_TestID",
                table: "Surgeries",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID");
            string getall = @"create proc SpAllWasteManagement
              as
              BEGIN
              SELECT * FROM WasteManagements
              END";
            string getbyid = @"create proc SpWasteManagementsgetById(@id int)
            as
            BEGIN
            SELECT * FROM WasteManagements where WasteID=@id 
            END";

            string InsertWasteManagement = @"
       CREATE PROCEDURE InsertWasteManagement
            @WasteType INT,
            @DisposalDate DATETIME,
            @DisposalMethod NVARCHAR(255),
            @Quantity INT,
            @NextScheduleDate DATETIME,
            @ContactNumber NVARCHAR(255)
        AS
        BEGIN
            INSERT INTO WasteManagements (WasteType, DisposalDate, DisposalMethod, Quantity, NextScheduleDate, ContactNumber)
            VALUES (@WasteType, @DisposalDate, @DisposalMethod, @Quantity, @NextScheduleDate, @ContactNumber);
        END";

            string UpdateWasteManagement = @"
        CREATE PROCEDURE UpdateWasteManagement
            @WasteID INT,
            @WasteType INT,
            @DisposalDate DATETIME,
            @DisposalMethod NVARCHAR(255),
            @Quantity INT,
            @NextScheduleDate DATETIME,
            @ContactNumber NVARCHAR(255)
        AS
        BEGIN
            UPDATE WasteManagements
            SET WasteType = @WasteType,
                DisposalDate = @DisposalDate,
                DisposalMethod = @DisposalMethod,
                Quantity = @Quantity,
                NextScheduleDate = @NextScheduleDate,
                ContactNumber = @ContactNumber
            WHERE WasteID = @WasteID;
        END
    ";
            string DeleteWasteManagement = @"
        CREATE PROCEDURE DeleteWasteManagement
            @WasteID INT
        AS
        BEGIN
            DELETE FROM WasteManagements
            WHERE WasteID = @WasteID;
        END
    ";
            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertWasteManagement);
            migrationBuilder.Sql(UpdateWasteManagement);
            migrationBuilder.Sql(DeleteWasteManagement);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surgeries_Tests_TestID",
                table: "Surgeries");

            migrationBuilder.AlterColumn<int>(
                name: "TestID",
                table: "Surgeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Surgeries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Surgeries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Preoperative_Diagnosis",
                table: "Surgeries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_DoctorID",
                table: "Surgeries",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Surgeries_Doctors_DoctorID",
                table: "Surgeries",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surgeries_Tests_TestID",
                table: "Surgeries",
                column: "TestID",
                principalTable: "Tests",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);
            string getall = @"Drop proc SpAllWasteManagement";
            string getbyid = @"Drop proc SpWasteManagementsgetById";
            string InsertWasteManagement = @"Drop proc InsertWasteManagement";
            string UpdateWasteManagement = @"Drop proc UpdateWasteManagement";
            string DeleteWasteManagement = @"Drop proc DeleteWasteManagement";
            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertWasteManagement);
            migrationBuilder.Sql(UpdateWasteManagement);
            migrationBuilder.Sql(DeleteWasteManagement);
        }
    }
}
