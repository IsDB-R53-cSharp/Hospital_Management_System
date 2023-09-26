using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class UnidentifiedDeadBody : Migration
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

            migrationBuilder.DropTable(
                name: "LabEquipments");

            migrationBuilder.DropIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.RenameColumn(
                name: "DrawerCount",
                table: "Drawers",
                newName: "DrawerCondition");

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Drawers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "unidentifiedDeadBodies",
                columns: table => new
                {
                    UnIdenfiedDeadBodyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<int>(type: "int", nullable: false),
                    DeceasedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "date", nullable: true),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidentifiedDeadBodies", x => x.UnIdenfiedDeadBodyID);
                });

            migrationBuilder.CreateTable(
                name: "DrawersInfo",
                columns: table => new
                {
                    DrawerInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    DrawerID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    UnidentifiedDeadBodyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawersInfo", x => x.DrawerInfoID);
                    table.ForeignKey(
                        name: "FK_DrawersInfo_Drawers_DrawerID",
                        column: x => x.DrawerID,
                        principalTable: "Drawers",
                        principalColumn: "DrawerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawersInfo_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_DrawersInfo_unidentifiedDeadBodies_UnidentifiedDeadBodyID",
                        column: x => x.UnidentifiedDeadBodyID,
                        principalTable: "unidentifiedDeadBodies",
                        principalColumn: "UnIdenfiedDeadBodyID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_DrawerID",
                table: "DrawersInfo",
                column: "DrawerID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_PatientID",
                table: "DrawersInfo",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_UnidentifiedDeadBodyID",
                table: "DrawersInfo",
                column: "UnidentifiedDeadBodyID");

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Cascade);

            string getall = @"create proc SpAllUnidentifiedDeadBody
              as
              BEGIN
              SELECT * FROM UnidentifiedDeadBody
              END";
            string getbyid = @"create proc SpUnidentifiedDeadBodygetById(@id int)
            as
            BEGIN
            SELECT * FROM UnidentifiedDeadBody where UnIdenfiedDeadBodyID=@id 
            END";
            string InsertUnidentifiedDeadBody = @"
            CREATE PROCEDURE InsertUnidentifiedDeadBody
                @TagNumber INT,
                @DeceasedName NVARCHAR(200)
                @DateOfDeath date,
                @CauseOfDeath date
            AS
            BEGIN
                INSERT INTO UnidentifiedDeadBody (TagNumber,DeceasedName, DateOfDeath,CauseOfDeath)
                VALUES (@TagNumber, @DeceasedName, @DateOfDeath, @CauseOfDeath);
            END";
            string UpdateUnidentifiedDeadBody = @"
            CREATE PROCEDURE UpdateUnidentifiedDeadBody
                @TagNumber INT,
                @DeceasedName NVARCHAR(200)
                @DateOfDeath date,
                @CauseOfDeath date
            AS
            BEGIN
                UPDATE UnidentifiedDeadBody
                SET TagNumber = @TagNumber,
                    DeceasedName = @DeceasedName,
                    DateOfDeath = @DateOfDeath,
                    CauseOfDeath = @CauseOfDeath
                WHERE UnIdenfiedDeadBodyID = @UnIdenfiedDeadBodyID;
            END";
            string DeleteUnidentifiedDeadBody = @"
            CREATE PROCEDURE DeleteUnidentifiedDeadBody
                @UnIdenfiedDeadBodyID INT
            AS
            BEGIN
                DELETE FROM UnidentifiedDeadBody
                WHERE UnIdenfiedDeadBodyID = @UnIdenfiedDeadBodyID;
            END";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertUnidentifiedDeadBody);
            migrationBuilder.Sql(UpdateUnidentifiedDeadBody);
            migrationBuilder.Sql(DeleteUnidentifiedDeadBody);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropTable(
                name: "DrawersInfo");

            migrationBuilder.DropTable(
                name: "unidentifiedDeadBodies");

            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Drawers");

            migrationBuilder.RenameColumn(
                name: "DrawerCondition",
                table: "Drawers",
                newName: "DrawerCount");

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

            migrationBuilder.CreateTable(
                name: "LabEquipments",
                columns: table => new
                {
                    EquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    EquipmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabEquipments", x => x.EquipmentID);
                    table.ForeignKey(
                        name: "FK_LabEquipments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionsPrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions",
                column: "PatientRegisterPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_LabEquipments_DepartmentID",
                table: "LabEquipments",
                column: "DepartmentID");

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

            string getall = @"Drop proc SpAllUnidentifiedDeadBody";
            string getbyid = @"Drop proc SpUnidentifiedDeadBodygetById";
            string InsertUnidentifiedDeadBody = @"Drop proc InsertUnidentifiedDeadBody";
            string UpdateUnidentifiedDeadBody = @"Drop proc UpdateUnidentifiedDeadBody";
            string DeleteUnidentifiedDeadBody = @"Drop proc DeleteUnidentifiedDeadBody";


            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertUnidentifiedDeadBody);
            migrationBuilder.Sql(UpdateUnidentifiedDeadBody);
            migrationBuilder.Sql(DeleteUnidentifiedDeadBody);
        }
    }
}
