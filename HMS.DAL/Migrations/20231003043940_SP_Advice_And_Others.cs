using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class SP_Advice_And_Others : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "WardCabinType",
                table: "WardCabins",
                type: "int",
                nullable: false,
                defaultValue: 0);

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



            //--Create Stored Procedure for Retrieving All Symptoms

            string getAllAdvice = @"CREATE PROCEDURE GetAdviceList
                                AS
                                BEGIN
                                    SELECT * FROM Advices
                                END";

            //--Create Stored Procedure for Retrieving a Specific Symptom by ID

            string getAdviceById = @"CREATE PROCEDURE GetAdviceById
                                @AdviceId int 
                                AS 
                                BEGIN
                                SELECT * FROM Advices WHERE AdviceId=@AdviceId
                                END";

            //--Create Stored Procedure for Inserting a New Symptom
            string insertAdvice = @"CREATE PROCEDURE InsertAdvice
                                    @AdviceName VARCHAR(MAX)
                                AS
                                BEGIN
                                    INSERT INTO Advices (AdviceName)
                                    VALUES (@AdviceName)
                                END";

            //--Create Stored Procedure for Updating an Existing Symptom

            string updateAdvice = @"CREATE PROCEDURE UpdateAdvice
                                    @AdviceId INT,
                                    @NewAdviceName VARCHAR(MAX)
                                AS
                                BEGIN
                                    UPDATE Advices
                                    SET AdviceName = @NewAdviceName
                                    WHERE AdviceId = @AdviceId
                                END";

            //--Create Stored Procedure for Deleting a Symptom by ID

            string deleteAdvice = @"CREATE PROCEDURE DeleteAdvice
                                @AdviceId INT
                            AS
                            BEGIN
                                DELETE FROM Advices
                                WHERE AdviceId = @AdviceId
                            END";

            migrationBuilder.Sql(getAllAdvice);
            migrationBuilder.Sql(getAdviceById);
            migrationBuilder.Sql(insertAdvice);
            migrationBuilder.Sql(updateAdvice);
            migrationBuilder.Sql(deleteAdvice);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            string getAllAdvice = @"Drop proc GetAdviceList";
            string getAdviceById = @"Drop proc GetAdviceById";
            string insertAdvice = @"Drop proc InsertAdvice";
            string updateAdvice = @"Drop proc UpdateAdvice";
            string deleteAdvice = @"Drop proc DeleteAdvice";

            migrationBuilder.Sql(getAllAdvice);
            migrationBuilder.Sql(getAdviceById);
            migrationBuilder.Sql(insertAdvice);
            migrationBuilder.Sql(updateAdvice);
            migrationBuilder.Sql(deleteAdvice);



            migrationBuilder.DropForeignKey(
                name: "FK_Surgeries_Tests_TestID",
                table: "Surgeries");

            migrationBuilder.DropColumn(
                name: "WardCabinType",
                table: "WardCabins");

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
        }
    }
}
