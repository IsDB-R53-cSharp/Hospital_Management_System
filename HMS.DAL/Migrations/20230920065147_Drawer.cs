using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Drawer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drawers_Morgues_MorgueID",
                table: "Drawers");

            migrationBuilder.DropIndex(
                name: "IX_Drawers_MorgueID",
                table: "Drawers");

            migrationBuilder.DropColumn(
                name: "MorgueID",
                table: "Drawers");

            migrationBuilder.AddColumn<int>(
                name: "DrawerId",
                table: "Morgues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Morgues_DrawerId",
                table: "Morgues",
                column: "DrawerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Morgues_Drawers_DrawerId",
                table: "Morgues",
                column: "DrawerId",
                principalTable: "Drawers",
                principalColumn: "DrawerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Morgues_Drawers_DrawerId",
                table: "Morgues");

            migrationBuilder.DropIndex(
                name: "IX_Morgues_DrawerId",
                table: "Morgues");

            migrationBuilder.DropColumn(
                name: "DrawerId",
                table: "Morgues");

            migrationBuilder.AddColumn<int>(
                name: "MorgueID",
                table: "Drawers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_MorgueID",
                table: "Drawers",
                column: "MorgueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Drawers_Morgues_MorgueID",
                table: "Drawers",
                column: "MorgueID",
                principalTable: "Morgues",
                principalColumn: "MorgueID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
