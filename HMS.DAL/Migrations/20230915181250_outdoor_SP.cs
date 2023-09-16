using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class outdoor_SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //auto add hoise
            migrationBuilder.AlterColumn<string>(
                name: "LastLocation",
                table: "Ambulances",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //auto add hoise
            migrationBuilder.AlterColumn<string>(
                name: "DriverName",
                table: "Ambulances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //Store Procedure code
            //var procGetOutdoorById = @"
            //    -- Retrieve an Outdoor entity by OutdoorID
            //    CREATE PROCEDURE GetOutdoorById
            //        @Id INT
            //    AS
            //    BEGIN
            //        BEGIN TRY
            //            SELECT * FROM Outdoors WHERE OutdoorID = @Id;
            //        END TRY
            //        BEGIN CATCH
            //            PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //        END CATCH;
            //    END;
            //    ";

            //var procGetAllOutdoors = @"
            //-- Stored Procedure to Retrieve All Outdoor Records
            //CREATE PROCEDURE GetAllOutdoors
            //AS
            //BEGIN
            //    BEGIN TRY
            //        SELECT * FROM Outdoors;
            //    END TRY
            //    BEGIN CATCH
            //        -- Handle the error here
            //        PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //    END CATCH;
            //}
            //";

            //var procGetOutdoorsByPatientId = @"
            //-- Stored Procedure to Retrieve Outdoor Records for a Specific Patient
            //CREATE PROCEDURE GetOutdoorsByPatientId
            //    @PatientId INT
            //AS
            //BEGIN
            //    BEGIN TRY
            //        SELECT * FROM Outdoors WHERE PatientID = @PatientId;
            //    END TRY
            //    BEGIN CATCH
            //        -- Handle the error here
            //        PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //    END CATCH;
            //}
            //";

            //var procGetOutdoorsByTreatmentType = @"
            //-- Stored Procedure to Retrieve Outdoor Records by Treatment Type
            //CREATE PROCEDURE GetOutdoorsByTreatmentType
            //    @TreatmentType INT
            //AS
            //BEGIN
            //    BEGIN TRY
            //        SELECT * FROM Outdoors WHERE TreatmentType = @TreatmentType;
            //    END TRY
            //    BEGIN CATCH
            //        -- Handle the error here
            //        PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //    END CATCH;
            //}
            //";

            //var procGetOutdoorsByTreatmentDate = @"
            //-- Stored Procedure to Retrieve Outdoor Records by Treatment Date
            //CREATE PROCEDURE GetOutdoorsByTreatmentDate
            //    @TreatmentDate DATE
            //AS
            //BEGIN
            //    BEGIN TRY
            //        SELECT * FROM Outdoors WHERE TreatmentDate = @TreatmentDate;
            //    END TRY
            //    BEGIN CATCH
            //        -- Handle the error here
            //        PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //    END CATCH;
            //}
            //";

            //var procGetOutdoorsByDoctorId = @"
            //-- Stored Procedure to Retrieve Outdoor Records by Doctor ID
            //CREATE PROCEDURE GetOutdoorsByDoctorId
            //    @DoctorId INT
            //AS
            //BEGIN
            //    BEGIN TRY
            //        SELECT * FROM Outdoors WHERE DoctorID = @DoctorId;
            //    END TRY
            //    BEGIN CATCH
            //        -- Handle the error here
            //        PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //    END CATCH;
            //}
            //";

            //var procAddOutdoor = @"
            //-- Stored Procedure to Add a New Outdoor Entity
            //CREATE PROCEDURE AddOutdoor
            //    @PatientID INT,
            //    @TreatmentType INT,
            //    @TreatmentDate DATE,
            //    @TicketNumber NVARCHAR(255),
            //    @BillID INT,
            //    @DoctorID INT,
            //    @Remarks NVARCHAR(MAX),
            //    @IsAdmissionRequired BIT
            //AS
            //BEGIN
            //    BEGIN TRY
            //        INSERT INTO Outdoors (PatientID, TreatmentType, TreatmentDate, TicketNumber, BillID, DoctorID, Remarks, IsAdmissionRequired)
            //        VALUES (@PatientID, @TreatmentType, @TreatmentDate, @TicketNumber, @BillID, @DoctorID, @Remarks, @IsAdmissionRequired);
            //    END TRY
            //    BEGIN CATCH
            //        -- Handle the error here
            //        PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //    END CATCH;
            //}
            //";

            //var procUpdateOutdoor = @"
            //-- Stored Procedure to Update an Outdoor Entity
            //CREATE PROCEDURE UpdateOutdoor
            //    @OutdoorID INT,
            //    @PatientID INT,
            //    @TreatmentType INT,
            //    @TreatmentDate DATE,
            //    @TicketNumber NVARCHAR(255),
            //    @BillID INT,
            //    @DoctorID INT,
            //    @Remarks NVARCHAR(MAX),
            //    @IsAdmissionRequired BIT
            //AS
            //BEGIN
            //    BEGIN TRY
            //        UPDATE Outdoors
            //        SET PatientID = @PatientID,
            //            TreatmentType = @TreatmentType,
            //            TreatmentDate = @TreatmentDate,
            //            TicketNumber = @TicketNumber,
            //            BillID = @BillID,
            //            DoctorID = @DoctorID,
            //            Remarks = @Remarks,
            //            IsAdmissionRequired = @IsAdmissionRequired
            //        WHERE OutdoorID = @OutdoorID;
            //    END TRY
            //    BEGIN CATCH
            //        -- Handle the error here
            //        PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //    END CATCH;
            //}
            //";

            //var procDeleteOutdoor = @"
            //-- Stored Procedure to Delete an Outdoor Entity
            //        CREATE PROCEDURE DeleteOutdoor
            //            @OutdoorID INT
            //        AS
            //        BEGIN
            //            BEGIN TRY
            //                DELETE FROM Outdoors WHERE OutdoorID = @OutdoorID;
            //            END TRY
            //            BEGIN CATCH
            //                -- Handle the error here
            //                PRINT 'An error occurred: ' + ERROR_MESSAGE();
            //            END CATCH;
            //        }
            //        ";

            //migrationBuilder.Sql(procGetOutdoorById);
            //migrationBuilder.Sql(procGetAllOutdoors);
            //migrationBuilder.Sql(procGetOutdoorsByPatientId);
            //migrationBuilder.Sql(procGetOutdoorsByTreatmentType);
            //migrationBuilder.Sql(procGetOutdoorsByTreatmentDate);
            //migrationBuilder.Sql(procGetOutdoorsByDoctorId);
            //migrationBuilder.Sql(procAddOutdoor);
            //migrationBuilder.Sql(procUpdateOutdoor);
            //migrationBuilder.Sql(procDeleteOutdoor);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastLocation",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DriverName",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            //migrationBuilder.Sql("DROP PROCEDURE GetOutdoorById;");
            //migrationBuilder.Sql("DROP PROCEDURE GetAllOutdoors;");
            //migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByPatientId;");
            //migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByTreatmentType;");
            //migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByTreatmentDate;");
            //migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByDoctorId;");
            //migrationBuilder.Sql("DROP PROCEDURE AddOutdoor;");
            //migrationBuilder.Sql("DROP PROCEDURE UpdateOutdoor;");
            //migrationBuilder.Sql("DROP PROCEDURE DeleteOutdoor;");
        }
    }
}
