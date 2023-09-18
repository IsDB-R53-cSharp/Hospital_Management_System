using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Ataur_Store_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string getall = @"create proc SpAllAmbulances
              as
              BEGIN
              SELECT * FROM Ambulances
              END";
            string getbyid = @"create proc SpAmbulancesgetById(@id int)
            as
            BEGIN
            SELECT * FROM Ambulances where AmbulanceID=@id 
            END";
            string InsertAmbulance = @"
            CREATE PROCEDURE InsertAmbulance
                @AmbulanceNumber NVARCHAR(10),
                @PhoneNumber NVARCHAR(20),
                @DrivingLiense NVARCHAR(20),
                @DriverName NVARCHAR(50),
                @LastLocation NVARCHAR(200),
                @Availability BIT
            AS
            BEGIN
                INSERT INTO Ambulances (AmbulanceNumber, PhoneNumber, DrivingLiense, DriverName, LastLocation, Availability)
                VALUES (@AmbulanceNumber, @PhoneNumber, @DrivingLiense, @DriverName, @LastLocation, @Availability);
            END";
            string UpdateAmbulance = @"
            CREATE PROCEDURE UpdateAmbulance
                @AmbulanceID INT,
                @AmbulanceNumber NVARCHAR(10),
                @PhoneNumber NVARCHAR(20),
                @DrivingLiense NVARCHAR(20),
                @DriverName NVARCHAR(50),
                @LastLocation NVARCHAR(200),
                @Availability BIT
            AS
            BEGIN
                UPDATE Ambulances
                SET AmbulanceNumber = @AmbulanceNumber,
                    PhoneNumber = @PhoneNumber,
                    DrivingLiense = @DrivingLiense,
                    DriverName = @DriverName,
                    LastLocation = @LastLocation,
                    Availability = @Availability
                WHERE AmbulanceID = @AmbulanceID;
            END";
            string DeleteAmbulance = @"
            CREATE PROCEDURE DeleteAmbulance
                @AmbulanceID INT
            AS
            BEGIN
                DELETE FROM Ambulances
                WHERE AmbulanceID = @AmbulanceID;
            END";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertAmbulance);
            migrationBuilder.Sql(UpdateAmbulance);
            migrationBuilder.Sql(DeleteAmbulance);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string getall = @"Drop proc SpAllAmbulances";
            string getbyid = @"Drop proc SpAmbulancesgetById";
            string InsertAmbulance = @"Drop proc InsertAmbulance";
            string UpdateAmbulance = @"Drop proc UpdateAmbulance";
            string DeleteAmbulance = @"Drop proc DeleteAmbulance";


            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertAmbulance);
            migrationBuilder.Sql(UpdateAmbulance);
            migrationBuilder.Sql(DeleteAmbulance);
        }
    }
}
