﻿using Microsoft.EntityFrameworkCore.Migrations;

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
            var procGetOutdoorById = @"
                -- stored procedure ==> Get Any Outdoor record By Id
                CREATE PROCEDURE GetOutdoorById
                    @Id INT
                AS
                BEGIN
                    BEGIN TRY
                        DECLARE @Result INT

                        SELECT @Result = COUNT(*) FROM Outdoors WHERE OutdoorID = @Id

                        IF @Result = 0
                        BEGIN
                            THROW 50000, 'Outdoor ID not found', 1
                        END
                        SELECT * FROM Outdoors WHERE OutdoorID = @Id
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";

            var procGetAllOutdoors = @"
                -- stored procedure ==> Get All Outdoors record
                CREATE PROCEDURE GetAllOutdoors
                AS
                BEGIN
                    BEGIN TRY
                        -- records in the Outdoors table
                        IF NOT EXISTS (SELECT 1 FROM Outdoors)
                        BEGIN
                            --  no records
                            THROW 50001, 'No Outdoor record found', 1
                        END

                        SELECT * FROM Outdoors
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                --test
                EXEC GetAllOutdoors
                ";

            var procGetOutdoorsByPatientId = @"
                -- stored procedure ==> Get Outdoor record By searching PatientId
                CREATE PROCEDURE GetOutdoorsByPatientId
                    @PatientId INT
                AS
                BEGIN
                    BEGIN TRY
                        --If PatientRegisters doesn't have PatientID
                        IF NOT EXISTS (SELECT 1 FROM PatientRegisters WHERE PatientID = @PatientId)
                        BEGIN
                            THROW 50002, 'PatientID not Exist!! ', 1
                        END
                        ELSE
                        BEGIN
                            -- specific patient hasn't received any treatment (in Outdoor)
                            IF NOT EXISTS (SELECT 1 FROM Outdoors WHERE PatientID = @PatientId)
                            BEGIN
                                -- PatientRegisters has PatientID, but outdoor haven't
                                THROW 50003, 'This PatientID exist but It hasn''t received any treatment in Outdoor yet', 2
                            END
                            SELECT * FROM Outdoors WHERE PatientID = @PatientId
                        END
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";

            var procGetOutdoorsByTreatmentType = @"
                -- stored procedure ==> GetOutdoorsByTreatmentType
                CREATE PROCEDURE GetOutdoorsByTreatmentType
                    @TreatmentType INT
                AS
                BEGIN
                    BEGIN TRY
                        --  if the TreatmentType exists
                        IF NOT EXISTS (SELECT 1 FROM Outdoors WHERE TreatmentType = @TreatmentType)
                        BEGIN
                            -- when TreatmentType is not found in Outdoor history // not necessary because of enum
                            THROW 50004, 'This type of treatment not exist in Outdoor', 1
                        END
                        ELSE
                        BEGIN
                            --TreatmentType exists, but specific treatment records don't exist
                            IF EXISTS (SELECT 1 FROM Outdoors WHERE TreatmentType = @TreatmentType AND PatientID IS NULL )
                            BEGIN
                                THROW 50005, 'No Outdoor record found for this type of Treatment', 2
                            END
                            SELECT * FROM Outdoors WHERE TreatmentType = @TreatmentType
                        END
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";

            var procGetOutdoorsByTreatmentDate = @"
                -- stored procedure ==> GetOutdoorsByTreatmentDate
                CREATE PROCEDURE GetOutdoorsByTreatmentDate
                    @TreatmentDate DATE
                AS
                BEGIN
                    BEGIN TRY
                        -- check records for specific Date
                        IF NOT EXISTS (SELECT 1 FROM Outdoors WHERE TreatmentDate = @TreatmentDate)
                        BEGIN
                            --  no records for specified date
                            THROW 50006, 'No outdoor record found for this date', 1
                        END
                        SELECT * FROM Outdoors WHERE TreatmentDate = @TreatmentDate
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";


            var procGetOutdoorsByDoctorId = @"
                -- stored procedure ==> Get Outdoor record By searching DoctorId
                CREATE PROCEDURE GetOutdoorsByDoctorId
                    @DoctorId INT
                AS
                BEGIN
                    BEGIN TRY
                        -- Check DoctorID exists or not
                        IF NOT EXISTS (SELECT 1 FROM Doctors WHERE DoctorID = @DoctorId)
                        BEGIN
                        -- if DoctorID is not found
                        THROW 50007, 'DoctorID not exist', 1
                        END

                        --DoctorID exists in the Outdoors table but never give treatment
                        IF EXISTS (SELECT 1 FROM Outdoors WHERE DoctorID = @DoctorId AND PatientID IS NULL)
                        BEGIN
                            THROW 50008, 'This Doctor never gave any treatments in Outdoor', 2
                        END
                        -- DoctorID exists + treatment record are found
                        SELECT * FROM Outdoors WHERE DoctorID = @DoctorId
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";

            var procAddOutdoor = @"
                -- stored procedure ==> Add new Outdoor record
                CREATE PROCEDURE AddOutdoor
                    @PatientID INT,
                    @TreatmentType INT,
                    @TreatmentDate DATE,
                    @TicketNumber NVARCHAR(255),
                    @BillID INT,
                    @DoctorID INT,
                    @Remarks NVARCHAR(MAX),
                    @IsAdmissionRequired BIT
                AS
                BEGIN
                    BEGIN TRY
                        -- Check if the TicketNumber already exists
                        IF EXISTS (SELECT 1 FROM Outdoors WHERE TicketNumber = @TicketNumber)
                        BEGIN
                            -- error for duplicate outdoor ID
                            THROW 50009, 'Duplicate TicketNumber not allowed', 1
                        END

                        -- Check if PatientID is null
                        IF @DoctorID IS NULL
                        BEGIN
                            -- error for missing DoctorID
                            THROW 50010, 'You can''t insert outdoor record without DoctorID', 2
                        END

		                -- Check if PatientID is null
                        IF @PatientID IS NULL
                        BEGIN
                            -- error for missing PatientID
                            THROW 50011, 'You can''t insert outdoor record without PatientID', 1
                        END

		                -- Check if TreatmentDate is tomorrow or later
		                IF DATEDIFF(DAY, GETDATE(), @TreatmentDate) > 0
		                BEGIN
			                -- error for incorrect TreatmentDate
			                THROW 50012, 'Date selection is wrong', 3
		                END

                        -- If PaymentStatus is Due, auto-populate Remarks
                        //IF EXISTS (SELECT 1 FROM Bills WHERE BillID = @BillID AND PaymentStatus = 2) -- PaymentStatus enum index 2 means 'Due'
                        //BEGIN
                        //    SET @Remarks = 'Payment due'
                        //END

                        -- Insert the record into Outdoors
                        INSERT INTO Outdoors (PatientID, TreatmentType, TreatmentDate, TicketNumber, BillID, DoctorID, Remarks, IsAdmissionRequired)
                        VALUES (@PatientID, @TreatmentType, @TreatmentDate, @TicketNumber, @BillID, @DoctorID, @Remarks, @IsAdmissionRequired)
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";

            var procUpdateOutdoor = @"
                -- stored procedure ==> UpdateOutdoor
                CREATE PROCEDURE UpdateOutdoor
                    @OutdoorID INT,
                    @PatientID INT,
                    @TreatmentType INT,
                    @TreatmentDate DATE,
                    @TicketNumber NVARCHAR(255),
                    @BillID INT,
                    @DoctorID INT,
                    @Remarks NVARCHAR(MAX),
                    @IsAdmissionRequired BIT
                AS
                BEGIN
                    BEGIN TRY
		                --TicketNumber already exists
                        IF EXISTS (SELECT 1 FROM Outdoors WHERE TicketNumber = @TicketNumber AND OutdoorID != @OutdoorID)
                        BEGIN
                            -- for duplicate outdoor ID
                            THROW 50009, 'Duplicate TicketNumber not allowed', 1
                        END

                        IF @DoctorID IS NULL
                        BEGIN
                            -- for missing DoctorID
                            THROW 50010, 'You can''t update outdoor record without DoctorID', 2
                        END

                        IF @PatientID IS NULL
                        BEGIN
                            -- for missing PatientID
                            THROW 50011, 'You can''t update outdoor record without PatientID', 1
                        END

		                --TreatmentDate tomorrow = not allowed
		                IF DATEDIFF(DAY, GETDATE(), @TreatmentDate) > 0
		                BEGIN
			                THROW 50012, 'Date selection is wrong', 3
		                END

                        UPDATE Outdoors
                        SET PatientID = @PatientID,
                            TreatmentType = @TreatmentType,
                            TreatmentDate = @TreatmentDate,
                            TicketNumber = @TicketNumber,
                            BillID = @BillID,
                            DoctorID = @DoctorID,
                            Remarks = @Remarks,
                            IsAdmissionRequired = @IsAdmissionRequired
                        WHERE OutdoorID = @OutdoorID
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";

            var procDeleteOutdoor = @"
                -- stored procedure ==> DeleteOutdoor
                CREATE PROCEDURE DeleteOutdoor
                    @OutdoorID INT
                AS
                BEGIN
                    BEGIN TRY
                        DECLARE @Result INT

                        SELECT @Result = COUNT(*) FROM Outdoors WHERE OutdoorID = @OutdoorID

                        IF @Result = 0
                        BEGIN
                            --OutdoorID is not found
                            THROW 50000, 'Outdoor ID not found', 1
                        END

                        -- Delete the outdoor record since it exists  --- error?
                        --DELETE FROM Outdoors WHERE OutdoorID = @OutdoorID

		                -- Prevent delete outdoor
		                IF @OutdoorID is not null
                        THROW 50002, 'Outdoor record can''t be deleted', 2
                    END TRY
                    BEGIN CATCH
                        PRINT 'An error occurred: ' + ERROR_MESSAGE()
                    END CATCH
                END
                GO
                ";


            migrationBuilder.Sql(procGetOutdoorById);
            migrationBuilder.Sql(procGetAllOutdoors);
            migrationBuilder.Sql(procGetOutdoorsByPatientId);
            migrationBuilder.Sql(procGetOutdoorsByTreatmentType);
            migrationBuilder.Sql(procGetOutdoorsByTreatmentDate);
            migrationBuilder.Sql(procGetOutdoorsByDoctorId);
            migrationBuilder.Sql(procAddOutdoor);
            migrationBuilder.Sql(procUpdateOutdoor);
            migrationBuilder.Sql(procDeleteOutdoor);

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

            migrationBuilder.Sql("DROP PROCEDURE GetOutdoorById;");
            migrationBuilder.Sql("DROP PROCEDURE GetAllOutdoors;");
            migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByPatientId;");
            migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByTreatmentType;");
            migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByTreatmentDate;");
            migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByDoctorId;");
            migrationBuilder.Sql("DROP PROCEDURE AddOutdoor;");
            migrationBuilder.Sql("DROP PROCEDURE UpdateOutdoor;");
            migrationBuilder.Sql("DROP PROCEDURE DeleteOutdoor;");
        }
    }
}
