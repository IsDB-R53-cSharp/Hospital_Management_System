using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Nayeem_SPLabTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string getall = @"create proc SpAlltest 
		as
		BEGIN
            select * FROM LabTests
        END";
            string getbyid = @"create proc SptestgetById(@id int) 
		as
		BEGIN
            select * FROM LabTests where TestID=@id
        END";
            string Pinsert = @"create proc SPinsert (@Tname VARCHAR(10),
                      @Pric   DECIMAL(10, 2),
                      @PatientID  int,
					  @Result VARCHAR(max),
		              @TechnicianID int)
										  as 
										  BEGIN
						INSERT INTO LabTests
                        (
                         TestName,
                         Price,
                         PatientID,
                         Result,
						 TechnicianID)
                            VALUES     ( 
                         @Tname,
                         @Pric,
                         @PatientID,
						 @Result,
						 @TechnicianID)
										  END";
            string Pupdate = @"create proc SPUpdate (@id int,
                       @Tname VARCHAR(10),
                       @Pric   DECIMAL(10, 2),
                       @PatientID  int,
		               @Result VARCHAR(max),
					   @TechnicianID int)
										  as 
										  BEGIN
                UPDATE LabTests
                SET    TestName = @Tname,
                   Price = @Pric,
                   PatientID = @PatientID,
                   Result = @Result,
				   TechnicianID=@TechnicianID
                WHERE  TestID = @id
                END";
            string Pdelete = @"create proc SpDelete (@id int)
                as
                BEGIN
                DELETE FROM LabTests
                WHERE  TestID = @id
                END";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(Pinsert);
            migrationBuilder.Sql(Pupdate);
            migrationBuilder.Sql(Pdelete);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string getall = @"Drop proc SpAlltest";
            string getbyid = @"Drop proc SptestgetById";
            string Pinsert = @"Drop proc SPinsert";
            string Pupdate = @"Drop proc SPUpdate";
            string Pdelete = @"Drop proc SpDelete";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(Pinsert);
            migrationBuilder.Sql(Pupdate);
            migrationBuilder.Sql(Pdelete);
        }
    }
}
