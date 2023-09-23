using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class ModifyAmbulance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "DrivingLiense",
                table: "Ambulances");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Ambulances");

            migrationBuilder.AlterColumn<int>(
                name: "WasteType",
                table: "WasteManagements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AmbulanceID",
                table: "OtherEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastLocation",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_OtherEmployees_AmbulanceID",
                table: "OtherEmployees",
                column: "AmbulanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherEmployees_Ambulances_AmbulanceID",
                table: "OtherEmployees",
                column: "AmbulanceID",
                principalTable: "Ambulances",
                principalColumn: "AmbulanceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherEmployees_Ambulances_AmbulanceID",
                table: "OtherEmployees");

            migrationBuilder.DropIndex(
                name: "IX_OtherEmployees_AmbulanceID",
                table: "OtherEmployees");

            migrationBuilder.DropColumn(
                name: "AmbulanceID",
                table: "OtherEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "WasteType",
                table: "WasteManagements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastLocation",
                table: "Ambulances",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "Ambulances",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DrivingLiense",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Ambulances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
