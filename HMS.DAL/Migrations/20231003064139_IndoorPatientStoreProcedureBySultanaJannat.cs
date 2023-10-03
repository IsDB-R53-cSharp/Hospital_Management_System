using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class IndoorPatientStoreProcedureBySultanaJannat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string GetAllIndoorPatientsSP = @"CREATE PROCEDURE  GetAllIndoorPatients
                                            AS
                                            BEGIN
                                                SET NOCOUNT ON;

                                                SELECT * FROM IndoorPatients;
                                            END";
            string getIndoorPatientByID = @"CREATE PROCEDURE GetIndoorPatientByID
                                            @IndoorPatientID INT
                                        AS
                                        BEGIN
                                            SET NOCOUNT ON;

                                            SELECT * FROM IndoorPatients
                                            WHERE IndoorPatientID = @IndoorPatientID;
                                        END";
            string InsertIndoorPatientSP = @"CREATE PROCEDURE InsertIndoorPatient
                            @ReferredBy NVARCHAR(200),
                            @BedID INT,
                            @InsuranceInfo NVARCHAR(500) = NULL,
                            @AdmissionNotes NVARCHAR(500) = NULL,
                            @IsDead BIT,
                            @PatientID INT,
                            @MedicalRecordsID INT,
                            @NIDnumber NVARCHAR(11),
                            @AdmissionDate DATE,
                            @DateOfBirth DATE,
                            @EmergencyContact NVARCHAR(11),
                            @BloodType INT,
                            @IsTransferred BIT
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            INSERT INTO IndoorPatients (
                                ReferredBy, BedID, InsuranceInfo, AdmissionNotes, IsDead, PatientID, MedicalRecordsID,
                                NIDnumber, AdmissionDate, DateOfBirth, EmergencyContact, BloodType, IsTransferred
                            )
                            VALUES (
                                @ReferredBy, @BedID, @InsuranceInfo, @AdmissionNotes, @IsDead, @PatientID, @MedicalRecordsID,
                                @NIDnumber, @AdmissionDate, @DateOfBirth, @EmergencyContact, @BloodType, @IsTransferred
                            );

                            -- You can include additional logic here if needed.

                            DECLARE @IndoorPatientID INT;
                            SET @IndoorPatientID = SCOPE_IDENTITY();

                            SELECT @IndoorPatientID AS IndoorPatientID;
                        END";




            string UpdateIndoorPatientSP = @"CREATE PROCEDURE UpdateIndoorPatient
                                        @IndoorPatientID INT,
                                        @ReferredBy NVARCHAR(200),
                                        @BedID INT,
                                        @InsuranceInfo NVARCHAR(500) = NULL,
                                        @AdmissionNotes NVARCHAR(500) = NULL,
                                        @IsDead BIT,
                                        @PatientID INT,
                                        @MedicalRecordsID INT,
                                        @NIDnumber NVARCHAR(11),
                                        @AdmissionDate DATE,
                                        @DateOfBirth DATE,
                                        @EmergencyContact NVARCHAR(11),
                                        @BloodType INT,
                                        @IsTransferred BIT
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        UPDATE IndoorPatients
                                        SET
                                            ReferredBy = @ReferredBy,
                                            BedID = @BedID,
                                            InsuranceInfo = @InsuranceInfo,
                                            AdmissionNotes = @AdmissionNotes,
                                            IsDead = @IsDead,
                                            PatientID = @PatientID,
                                            MedicalRecordsID = @MedicalRecordsID,
                                            NIDnumber = @NIDnumber,
                                            AdmissionDate = @AdmissionDate,
                                            DateOfBirth = @DateOfBirth,
                                            EmergencyContact = @EmergencyContact,
                                            BloodType = @BloodType,
                                            IsTransferred = @IsTransferred
                                        WHERE IndoorPatientID = @IndoorPatientID;

                                        -- You can include additional logic here if needed.

                                        SELECT @@ROWCOUNT AS RowsAffected;
                                    END";


            string DeleteIndoorPatientSP = @"CREATE PROCEDURE DeleteIndoorPatient
                                    @IndoorPatientID INT
                                AS
                                BEGIN
                                    SET NOCOUNT ON;

                                    DELETE FROM IndoorPatients
                                    WHERE IndoorPatientID = @IndoorPatientID;

                                    -- You can include additional logic here if needed.

                                    SELECT @@ROWCOUNT AS RowsAffected;
                                END";
            migrationBuilder.Sql(GetAllIndoorPatientsSP);
            migrationBuilder.Sql(getIndoorPatientByID);
            migrationBuilder.Sql(InsertIndoorPatientSP);
            migrationBuilder.Sql(UpdateIndoorPatientSP);
            migrationBuilder.Sql(DeleteIndoorPatientSP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string GetAllIndoorPatientsSP = @"drop proc GetAllIndoorPatients";

            string getIndoorPatientByID = @"drop proc GetIndoorPatientByID";

            string InsertIndoorPatientSP = @"drop proc InsertIndoorPatient";

            string UpdateIndoorPatientSP = @"drop proc UpdateIndoorPatient";

            string DeleteIndoorPatientSP = @"drop proc DeleteIndoorPatient";


            migrationBuilder.Sql(GetAllIndoorPatientsSP);
            migrationBuilder.Sql(getIndoorPatientByID);
            migrationBuilder.Sql(InsertIndoorPatientSP);
            migrationBuilder.Sql(UpdateIndoorPatientSP);
            migrationBuilder.Sql(DeleteIndoorPatientSP);
        }
    }
}
