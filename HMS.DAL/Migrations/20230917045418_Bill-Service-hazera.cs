using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class BillServicehazera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Service_ServiceID",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Services_ServiceID",
                table: "Bills",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Services_ServiceID",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Service_ServiceID",
                table: "Bills",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ServiceID");
        }
    }
}
