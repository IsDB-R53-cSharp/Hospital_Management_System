using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class UnidentifiedDeadBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string getall = @"create proc SpAllUnidentifiedDeadBody
              as
              BEGIN
              SELECT * FROM UnidentifiedDeadBody
              END";
            string getbyid = @"create proc SpUnidentifiedDeadBodygetById(@id int)
            as
            BEGIN
            SELECT * FROM UnidentifiedDeadBody where UnIdenfiedDeadBodyID=@id 
            END";
            string InsertUnidentifiedDeadBody = @"
            CREATE PROCEDURE InsertUnidentifiedDeadBody
                @TagNumber INT,
                @DeceasedName NVARCHAR(200),
                @DateOfDeath date,
                @CauseOfDeath NVARCHAR(200)
            AS
            BEGIN
                INSERT INTO UnidentifiedDeadBody (TagNumber,DeceasedName, DateOfDeath,CauseOfDeath)
                VALUES (@TagNumber, @DeceasedName, @DateOfDeath, @CauseOfDeath);
            END";
            string UpdateUnidentifiedDeadBody = @"
            CREATE PROCEDURE UpdateUnidentifiedDeadBody
                @UnIdenfiedDeadBodyID INT,
                @TagNumber INT,
                @DeceasedName NVARCHAR(200),
                @DateOfDeath date,
                @CauseOfDeath NVARCHAR(200)
            AS
            BEGIN
                UPDATE UnidentifiedDeadBody
                SET TagNumber = @TagNumber,
                    DeceasedName = @DeceasedName,
                    DateOfDeath = @DateOfDeath,
                    CauseOfDeath = @CauseOfDeath
                WHERE UnIdenfiedDeadBodyID = @UnIdenfiedDeadBodyID;
            END";
            string DeleteUnidentifiedDeadBody = @"
            CREATE PROCEDURE DeleteUnidentifiedDeadBody
                @UnIdenfiedDeadBodyID INT
            AS
            BEGIN
                DELETE FROM UnidentifiedDeadBody
                WHERE UnIdenfiedDeadBodyID = @UnIdenfiedDeadBodyID;
            END";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertUnidentifiedDeadBody);
            migrationBuilder.Sql(UpdateUnidentifiedDeadBody);
            migrationBuilder.Sql(DeleteUnidentifiedDeadBody);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string getall = @"Drop proc SpAllUnidentifiedDeadBody";
            string getbyid = @"Drop proc SpUnidentifiedDeadBodygetById";
            string InsertUnidentifiedDeadBody = @"Drop proc InsertUnidentifiedDeadBody";
            string UpdateUnidentifiedDeadBody = @"Drop proc UpdateUnidentifiedDeadBody";
            string DeleteUnidentifiedDeadBody = @"Drop proc DeleteUnidentifiedDeadBody";


            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertUnidentifiedDeadBody);
            migrationBuilder.Sql(UpdateUnidentifiedDeadBody);
            migrationBuilder.Sql(DeleteUnidentifiedDeadBody);
        }
    }
}
