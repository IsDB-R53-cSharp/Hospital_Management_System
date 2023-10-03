using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class PatientRegisterStoreProcedureBySultanaJannat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string GetAllPatientSP = @"CREATE PROCEDURE GetAllPatients
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        SELECT * FROM PatientRegisters;
                                    END";
            string GetPAtientByIDSP = @"CREATE PROCEDURE GetPatientByID
                                        @PatientID INT
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        SELECT * FROM PatientRegisters
                                        WHERE PatientID = @PatientID;
                                    END";
            string SearchPatientByNameOrGender = @"CREATE PROCEDURE SearchPatients
                                                                    @SearchName NVARCHAR(100) = NULL,
                                                                    @SearchGender INT = NULL
                                                                    AS
                                                                    BEGIN
                                                                        SET NOCOUNT ON;

                                                                        SELECT * FROM PatientRegisters
                                                                        WHERE
                                                                            (@SearchName IS NULL OR PatientName LIKE '%' + @SearchName + '%')
                                                                            AND (@SearchGender IS NULL OR Gender = @SearchGender);
                                                                    END";
            string InsertPatientSP = @"CREATE PROCEDURE InsertPatient
                                @PatientName NVARCHAR(100),
                                @Gender INT,
                                @Address NVARCHAR(500) = NULL,
                                @PhoneNumber NVARCHAR(11),
                                @Email NVARCHAR(255) = NULL
                            AS
                            BEGIN
                                SET NOCOUNT ON;

                                INSERT INTO PatientRegisters (PatientName, Gender, Address, PhoneNumber, Email)
                                VALUES (@PatientName, @Gender, @Address, @PhoneNumber, @Email);

                                DECLARE @PatientID INT;
                                SET @PatientID = SCOPE_IDENTITY();

                                -- You can include additional logic here if needed, such as handling prescriptions or indoor patients.

                                SELECT @PatientID AS PatientID;
                            END";

            string UpdatePatientSP = @"CREATE PROCEDURE UpdatePatient
                                    @PatientID INT,
                                    @PatientName NVARCHAR(100),
                                    @Gender INT,
                                    @Address NVARCHAR(500) = NULL,
                                    @PhoneNumber NVARCHAR(11),
                                    @Email NVARCHAR(255) = NULL
                                AS
                                BEGIN
                                    SET NOCOUNT ON;

                                    UPDATE PatientRegisters
                                    SET PatientName = @PatientName,
                                        Gender = @Gender,
                                        Address = @Address,
                                        PhoneNumber = @PhoneNumber,
                                        Email = @Email
                                    WHERE PatientID = @PatientID;

                                    -- You can include additional logic here if needed, such as handling prescriptions or indoor patients.

                                    SELECT @@ROWCOUNT AS RowsAffected;
                                END";
            migrationBuilder.Sql(GetAllPatientSP);
            migrationBuilder.Sql(GetPAtientByIDSP);
            migrationBuilder.Sql(SearchPatientByNameOrGender);
            migrationBuilder.Sql(InsertPatientSP);
            migrationBuilder.Sql(UpdatePatientSP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string GetAllPatientSP = @"drop proc GetAllPatients";

            string GetPAtientByIDSP = @"drop proc GetPatientByID";

            string SearchPatientByNameOrGender = @"drop proc SearchPatients";

            string InsertPatientSP = @"drop proc InsertPatient";

            string UpdatePatientSP = @"drop proc UpdatePatient";


            migrationBuilder.Sql(GetAllPatientSP);
            migrationBuilder.Sql(GetPAtientByIDSP);
            migrationBuilder.Sql(SearchPatientByNameOrGender);
            migrationBuilder.Sql(InsertPatientSP);
            migrationBuilder.Sql(UpdatePatientSP);
        }
    }
}
