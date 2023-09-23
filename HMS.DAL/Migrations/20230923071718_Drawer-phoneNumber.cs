using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class DrawerphoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    DrawerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrawerCount = table.Column<int>(type: "int", nullable: false),
                    MorgueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.DrawerID);
                    table.ForeignKey(
                        name: "FK_Drawers_Morgues_MorgueID",
                        column: x => x.MorgueID,
                        principalTable: "Morgues",
                        principalColumn: "MorgueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_MorgueID",
                table: "Drawers",
                column: "MorgueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drawers");
        }
    }
}
