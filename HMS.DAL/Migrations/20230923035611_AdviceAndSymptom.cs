using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class AdviceAndSymptom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WasteType",
                table: "WasteManagements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AdviceId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SymptomId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

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
                name: "IX_Prescriptions_SymptomId",
                table: "Prescriptions",
                column: "SymptomId");

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
                name: "FK_Prescriptions_Advices_AdviceId",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Symptoms_SymptomId",
                table: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Advices");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_AdviceId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_SymptomId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "AdviceId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SymptomId",
                table: "Prescriptions");

            migrationBuilder.AlterColumn<string>(
                name: "WasteType",
                table: "WasteManagements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
