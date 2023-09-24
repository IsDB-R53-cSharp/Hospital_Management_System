using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Morgue_Modify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DrawerCount",
                table: "Drawers",
                newName: "DrawerCondition");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Morgues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsolationCapability",
                table: "Morgues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CauseOfDeath",
                table: "Drawers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeath",
                table: "Drawers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeceasedName",
                table: "Drawers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "Drawers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPatient",
                table: "Drawers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PatientID",
                table: "Drawers",
                type: "int",
                nullable: true);

            //Store Procedure

            string getall = @"create proc SpGetAllMorgues
              as
              BEGIN
              SELECT * FROM Morgues
              END";
            string getbyid = @"create proc SpMorguesgetById(@id int)
            as
            BEGIN
            SELECT * FROM Morgues where MorgueID=@id 
            END";
            string InsertMorgue = @"
            CREATE PROCEDURE InsertMorgue
                @MorgueName NVARCHAR(100),
                @Capacity,
                @IsolationCapability BIT
            AS
            BEGIN
                INSERT INTO Morgues (MorgueName,Capacity, IsolationCapability)
                VALUES (@MorgueName, @Capacity, @IsolationCapability);
            END";
            string UpdateMorgue = @"
            CREATE PROCEDURE UpdateMorgue
                @MorgueID INT,
                @MorgueName NVARCHAR(100),
            
                @Capacity,
                @IsolationCapability BIT
            AS
            BEGIN
                UPDATE Morgues
                SET MorgueName= @MorgueName,
                    Capacity = @Capacity,
                    IsolationCapability = @IsolationCapability
                WHERE MorgueID = @MorgueID;
            END";
            string DeleteMorgue = @"
            CREATE PROCEDURE DeleteMorgue
                @MorgueID INT
            AS
            BEGIN
                DELETE FROM Morgues
                WHERE MorgueID = @MorgueID;
            END";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertMorgue);
            migrationBuilder.Sql(UpdateMorgue);
            migrationBuilder.Sql(DeleteMorgue);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Morgues");

            migrationBuilder.DropColumn(
                name: "IsolationCapability",
                table: "Morgues");

            migrationBuilder.DropColumn(
                name: "CauseOfDeath",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "DeceasedName",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "IsPatient",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "PatientID",
                table: "Drawers");

            migrationBuilder.RenameColumn(
                name: "DrawerCondition",
                table: "Drawers",
                newName: "DrawerCount");

            //Store Procedure

            string getall = @"Drop proc SpGetAllMorgues";
            string getbyid = @"Drop proc SpMorguesgetById";
            string InsertMorgue = @"Drop proc InsertMorgue";
            string UpdateMorgue = @"Drop proc UpdateMorgue";
            string DeleteMorgue = @"Drop proc DeleteMorgue";


            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertMorgue);
            migrationBuilder.Sql(UpdateMorgue);
            migrationBuilder.Sql(DeleteMorgue);
        }
    }
}
