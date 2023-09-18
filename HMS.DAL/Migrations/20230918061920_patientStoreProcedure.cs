using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class patientStoreProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string getAllPatientRg = @"create proc SpAllPatient
		as
		BEGIN
            select * FROM PatientRegisters
        END";

            string getPatientByIdRg = @"create proc SpPatientGetById(@patientId int) 
		as
		BEGIN
            select * FROM PatientRegisters where PatientID=@patientId
        END";

            string PatientInsertRg = @"create proc SPpatientInsert (@patinetName nvarchar(100),
                      @gender   int,
                      @dateOfBirth date,
					  @address nvarchar(500),
		              @phoneNumber nvarchar(max),
					  @email nvarchar(max),
					  @emergencyContact nvarchar(200),
					  @admissionDate date,
					  @bloodType int,
					  @isTransferred bit,
					  @wardId int)
										  as 
										  BEGIN
						INSERT INTO PatientRegisters
                        (
                         PatientName,
                         Gender,
                         DateOfBirth,
                         Address,
						 PhoneNumber,
						 Email,
						 EmergencyContact,
						 AdmissionDate,
						 BloodType,
						 IsTransferred,
						 WardID)
            VALUES     ( 
                         @patinetName,
                         @gender,
                         @dateOfBirth,
						 @address,
						 @phoneNumber,
						 @email,
						 @emergencyContact,
						 @admissionDate,
						 @bloodType,
						 @isTransferred,
						 @wardId)
										  END
";


            string patientUpdateRg = @"create proc SPpatientUpdate (@patientId int,
					@patinetName nvarchar(100),
                      @gender   int,
                      @dateOfBirth date,
					  @address nvarchar(500),
		              @phoneNumber nvarchar(max),
					  @email nvarchar(max),
					  @emergencyContact nvarchar(200),
					  @admissionDate date,
					  @bloodType int,
					  @isTransferred bit,
					  @wardId int)
										  as 
										  BEGIN
            UPDATE PatientRegisters
            SET    PatientName=@patinetName,
					Gender=@gender,
					DateOfBirth=@dateOfBirth,
					Address=@address,
					PhoneNumber=@phoneNumber,
					Email=@email,
					EmergencyContact=@emergencyContact,
					AdmissionDate=@admissionDate,
					BloodType=@bloodType,
					IsTransferred=@isTransferred,
					WardID=@wardId

            WHERE  PatientID = @patientId
        END";

            string patientDeleteRg = @"create proc SpPatientDelete (@patientId int)
as
 BEGIN
            DELETE FROM PatientRegisters
            WHERE  PatientID = @patientId
        END";

            migrationBuilder.Sql(getAllPatientRg);
            migrationBuilder.Sql(getPatientByIdRg);
            migrationBuilder.Sql(PatientInsertRg);
            migrationBuilder.Sql(patientUpdateRg);
            migrationBuilder.Sql(patientDeleteRg);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string getAllPatientRg = @"drop proc SpAllPatient";

            string getPatientByIdRg = @"drop proc SpPatientGetById";

            string PatientInsertRg = @"drop proc SPpatientInsert";

            string patientUpdateRg = @"drop proc SPpatientUpdate";

            string patientDeleteRg = @"drop proc SpPatientDelete";


            migrationBuilder.Sql(getAllPatientRg);
            migrationBuilder.Sql(getPatientByIdRg);
            migrationBuilder.Sql(PatientInsertRg);
            migrationBuilder.Sql(patientUpdateRg);
            migrationBuilder.Sql(patientDeleteRg);
        }
    }
}
