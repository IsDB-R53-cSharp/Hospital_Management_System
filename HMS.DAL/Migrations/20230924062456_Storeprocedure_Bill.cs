using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Storeprocedure_Bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures");

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

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionsPrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions",
                column: "PatientRegisterPatientID");

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

            var procGetBillById = @"
                CREATE PROCEDURE GetBillById(@Id int)
                AS
                BEGIN
	                SELECT * FROM Bills WHERE BillID = @Id
                END
            ";

            var procGetAllBills = @"
                CREATE PROCEDURE GetAllBills
            AS
            BEGIN
                BEGIN TRY
                IF NOT EXISTS (SELECT 1 FROM Bills)
                BEGIN
                    THROW 50001, 'No Bills record found', 1
                END
	            SELECT * FROM Bills
                END TRY
                BEGIN CATCH
                PRINT 'An Error:' + ERROR_MESSAGE()
                END CATCH
            END
            ";
            var procGetBillByPatientId = @"
                CREATE PROCEDURE GetBillByPatientId(@Id INT)
                AS
                BEGIN
                SELECT p.PatientName,s.ServiceName,s.ServiceCharge,b.BillDate,b.BillAmount,b.Discount,b.PaidAmount,b.Due FROM Bills b
                INNER JOIN
                PatientRegisters p ON b.PatientID = p.PatientID
                INNER JOIN
                Services s ON s.ServiceID = b.ServiceID where p.PatientID = @Id
                END
                ";

            //
            var procGetBillsByBillDate = @"
                    CREATE PROCEDURE GetBillsByBillDate
                    (@BillDate DATE)
                    AS
                    BEGIN
                        BEGIN TRY
                            -- check records for specific Date
                            IF NOT EXISTS (SELECT 1 FROM Bills WHERE BillDate = @BillDate)
                            BEGIN
                                --  no records for specified date
                                THROW 50006, 'No outdoor record found for this date', 1
                            END
                            SELECT  p.PatientID,p.PatientName,s.ServiceName,s.ServiceCharge,b.BillAmount,b.Discount,b.PaidAmount,b.Due FROM Bills b
                            INNER JOIN
                            PatientRegisters p ON b.PatientID=p.PatientID
                            INNER JOIN 
                            Services s ON s.ServiceID=b.ServiceID where b.BillDate=@BillDate
                        END TRY
                        BEGIN CATCH
                            PRINT 'An error occurred: ' + ERROR_MESSAGE()
                        END CATCH
                    END
                ";


            //AddBills
            var procAddBills = @"
                CREATE PROCEDURE AddBills
                (@PatientID INT,
                @TransactionInfo NVARCHAR(500),
                @BillAmount DECIMAL(18, 2),
                @Discount DECIMAL(18, 2),
                @PaidAmount DECIMAL(18, 2),
                @Due DECIMAL(18, 2),
                @PaymentMethod INT,
                @PaymentStatus INT,
                @BillDate DATE,
                @isInsurance BIT,
                @InsuranceInfo NVARCHAR(500),
                @BillingAddress NVARCHAR(200),
                @BillingNotes NVARCHAR(500),
                @PreparedBy NVARCHAR(100),
                @ServiceID INT
                )
                AS
                BEGIN
                BEGIN TRY
                BEGIN TRANSACTION;
                    --PatientID null?
							IF @PatientID IS NULL
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50012, 'You can''t insert Bills record without PatientID', 1;
							END
							-- PatientID exists?
							ELSE IF NOT EXISTS (SELECT 1 FROM PatientRegisters WHERE PatientID = @PatientID)
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50013, 'Selected PatientID does not exist in the PatientRegister table', 6;
							END
               

                INSERT INTO Bills
                (PatientID,TransactionInfo,BillAmount,Discount,PaidAmount,Due,PaymentMethod,PaymentStatus,BillDate,isInsurance,InsuranceInfo,BillingAddress,BillingNotes,PreparedBy,ServiceID)
                VALUES
                (@PatientID,@TransactionInfo,@BillAmount,@Discount,@PaidAmount,@Due,@PaymentMethod,@PaymentStatus,@BillDate,@isInsurance,@InsuranceInfo,@BillingAddress,@BillingNotes,@PreparedBy,@ServiceID)
                 COMMIT TRANSACTION;
                END TRY
                BEGIN CATCH
							ROLLBACK TRANSACTION;
							PRINT 'An error occurred: ' + ERROR_MESSAGE();
				END CATCH
                END
            ";
            var procUpdateBills = @"
                CREATE PROCEDURE UpdateBills
                    (@BillID INT,
                    @PatientID INT,
                    @TransactionInfo NVARCHAR(500),
                    @BillAmount DECIMAL(18, 2),
                    @Discount DECIMAL(18, 2),
                    @PaidAmount DECIMAL(18, 2),
                    @Due DECIMAL(18, 2),
                    @PaymentMethod INT,
                    @PaymentStatus INT,
                    @BillDate DATE,
                    @isInsurance BIT,
                    @InsuranceInfo NVARCHAR(500),
                    @BillingAddress NVARCHAR(200),
                    @BillingNotes NVARCHAR(500),
                    @PreparedBy NVARCHAR(100),
                    @ServiceID INT
                    )
            AS
            BEGIN
            BEGIN TRY
                BEGIN TRANSACTION;
                IF @PatientID IS NULL
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50012, 'You can''t insert bills record without PatientID', 1;
							END
							-- PatientID exists?
							ELSE IF NOT EXISTS (SELECT 1 FROM PatientRegisters WHERE PatientID = @PatientID)
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50013, 'Selected PatientID does not exist in the PatientRegister table', 6;
							END
            UPDATE  Bills SET
	            PatientID=@PatientID,
	            TransactionInfo=@TransactionInfo,
	            BillAmount=@BillAmount,
	            Discount=@Discount,
	            PaidAmount=@PaidAmount,
	            Due=@Due,
	            PaymentMethod=@PaymentMethod,
	            PaymentStatus=@PaymentStatus,
	            BillDate=@BillDate,
	            isInsurance=@isInsurance,
	            InsuranceInfo=@InsuranceInfo,
	            BillingAddress=@BillingAddress,
	            BillingNotes=@BillingNotes,
	            PreparedBy=@PreparedBy,
	            ServiceID=@ServiceID
	            WHERE BillID=@BillID
                COMMIT TRANSACTION;
					END TRY
					BEGIN CATCH
						ROLLBACK TRANSACTION;
						PRINT 'An error occurred: ' + ERROR_MESSAGE();
					END CATCH
				END
            ";
            var procDeleteBills = @"
            CREATE PROCEDURE DeleteBills(@Id int)
            AS
            BEGIN

            DELETE FROM Bills WHERE BillID = @Id
            END
           
            ";
            migrationBuilder.Sql(procGetBillById);
            migrationBuilder.Sql(procGetAllBills);
            migrationBuilder.Sql(procGetBillByPatientId);
            migrationBuilder.Sql(procGetBillsByBillDate);
            migrationBuilder.Sql(procAddBills);
            migrationBuilder.Sql(procUpdateBills);
            migrationBuilder.Sql(procDeleteBills);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionsPrescriptionID",
                table: "SurgeryProcedures");

            migrationBuilder.DropColumn(
                name: "PatientRegisterPatientID",
                table: "Prescriptions");

            migrationBuilder.AddForeignKey(
                name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionID",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionID",
                onDelete: ReferentialAction.Cascade);

            var procGetBillById = @"DROP PROCEDURE GetBillById";
            var procGetAllBills = @"DROP PROCEDURE GetAllBills";
            var procGetBillByPatientId = @"DROP PROCEDURE GetBillByPatientId";
            var procGetBillsByBillDate = @"DROP PROCEDURE GetBillsByBillDate";
            var procAddBills = @"DROP PROCEDURE AddBills";
            var procUpdateBills = @"DROP PROCEDURE UpdateBills";
            var procDeleteBills = @"DROP PROCEDURE DeleteBills";

            migrationBuilder.Sql(procGetBillById);
            migrationBuilder.Sql(procGetAllBills);
            migrationBuilder.Sql(procGetBillByPatientId);
            migrationBuilder.Sql(procGetBillsByBillDate);
            migrationBuilder.Sql(procAddBills);
            migrationBuilder.Sql(procUpdateBills);
            migrationBuilder.Sql(procDeleteBills);
        }
    }
}
