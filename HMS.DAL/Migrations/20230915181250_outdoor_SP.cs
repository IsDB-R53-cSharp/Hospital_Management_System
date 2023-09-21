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
                    create PROCEDURE AddOutdoor
						@PatientID INT,
						@TreatmentType INT,
						@TreatmentDate DATE,
						@TicketNumber NVARCHAR(255),
						@DoctorID INT,
						@Remarks NVARCHAR(MAX),
						@IsAdmissionRequired BIT
					AS
					BEGIN
						BEGIN TRY
							BEGIN TRANSACTION;
							-- TicketNumber exists check
							IF EXISTS (SELECT 1 FROM Outdoors WHERE TicketNumber = @TicketNumber)
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50009, 'Duplicate TicketNumber not allowed', 1;
							END

							-- DoctorID null check
							IF @DoctorID IS NULL
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50010, 'You can''t insert outdoor record without Doctor Name', 2;
							END

							-- PatientID is null?
							IF @PatientID IS NULL
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50011, 'You can''t insert outdoor record without Patient Name', 1;
							END

                            -- TreatmentDate is Past Date or not
							IF @TreatmentDate < CAST(GETDATE() AS DATE)
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50012, 'Treatment Date must be today or a future date', 3;
							END

							-- Generate a temporary BillID
							DECLARE @NewBillID INT;
							INSERT INTO Bills (PatientID, TransactionInfo, BillAmount, Discount, PaidAmount, PaymentMethod, PaymentStatus, BillDate, isInsurance, InsuranceInfo, BillingAddress, BillingNotes, PreparedBy, ServiceID)
							VALUES (@PatientID, 'for outdoor', 0.00, NULL, 0.00, 0, 1, GETDATE(), 0, NULL, NULL, NULL, 'Cashier name', NULL);

							-- get newly generated BillID
							SET @NewBillID = SCOPE_IDENTITY();

							-- add new Outdoors record with new BillID
							INSERT INTO Outdoors (PatientID, TreatmentType, TreatmentDate, TicketNumber, BillID, DoctorID, Remarks, IsAdmissionRequired)
							VALUES (@PatientID, @TreatmentType, @TreatmentDate, @TicketNumber, @NewBillID, @DoctorID, @Remarks, @IsAdmissionRequired);

							COMMIT TRANSACTION;
						END TRY
						BEGIN CATCH
							ROLLBACK TRANSACTION;
							PRINT 'An error occurred: ' + ERROR_MESSAGE();
						END CATCH
					END
				GO
                ";

            var procUpdateOutdoor = @"
                -- stored procedure ==> UpdateOutdoor
                create PROCEDURE UpdateOutdoor
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
                        BEGIN TRANSACTION;
                        -- Ticket already exists for different BillID??
                        IF EXISTS (
                            SELECT 1
                            FROM Outdoors
                            WHERE TicketNumber = @TicketNumber
                              AND BillID <> @BillID
                        )
                        BEGIN
                            -- duplicate Ticket check
                            ROLLBACK TRANSACTION;
                            THROW 50013, 'TicketNumber is already associated with a different BillID', 1;
                        END

                        -- DoctorID NULL??
                        IF @DoctorID IS NULL
                        BEGIN
                            -- Rollback the transaction and throw an error for missing DoctorID
                            ROLLBACK TRANSACTION;
                            THROW 50010, 'You can''t update outdoor record without DoctorID', 2;
                        END

                        --PatientID NULL?
                        IF @PatientID IS NULL
                        BEGIN
                            ROLLBACK TRANSACTION;
                            THROW 50011, 'You can''t update outdoor record without PatientID', 1;
                        END

		                -- TreatmentDate past date or not
		                IF @TreatmentDate < CAST(GETDATE() AS DATE)
		                BEGIN
			                ROLLBACK TRANSACTION;
			                THROW 50012, 'Treatment Date must be today or a future date', 3;
		                END


                        -- Update the Outdoor record
                        UPDATE Outdoors
                        SET PatientID = @PatientID,
                            TreatmentType = @TreatmentType,
                            TreatmentDate = @TreatmentDate,
                            TicketNumber = @TicketNumber,
                            BillID = @BillID,
                            DoctorID = @DoctorID,
                            Remarks = @Remarks,
                            IsAdmissionRequired = @IsAdmissionRequired
                        WHERE OutdoorID = @OutdoorID;

                        COMMIT TRANSACTION;
                    END TRY
                    BEGIN CATCH
                        ROLLBACK TRANSACTION;
                        PRINT 'An error occurred: ' + ERROR_MESSAGE();
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
