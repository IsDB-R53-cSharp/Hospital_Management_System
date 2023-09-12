using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Billmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outdoors_Invoices_InvoiceID",
                table: "Outdoors");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "PatientRegisters",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "InvoiceID",
                table: "Outdoors",
                newName: "BillID");

            migrationBuilder.RenameIndex(
                name: "IX_Outdoors_InvoiceID",
                table: "Outdoors",
                newName: "IX_Outdoors_BillID");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TransactionInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Due = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    BillDate = table.Column<DateTime>(type: "date", nullable: false),
                    isInsurance = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillingNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_Bills_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bills_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_PatientID",
                table: "Bills",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ServiceID",
                table: "Bills",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Outdoors_Bills_BillID",
                table: "Outdoors",
                column: "BillID",
                principalTable: "Bills",
                principalColumn: "BillID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outdoors_Bills_BillID",
                table: "Outdoors");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "PatientRegisters",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "BillID",
                table: "Outdoors",
                newName: "InvoiceID");

            migrationBuilder.RenameIndex(
                name: "IX_Outdoors_BillID",
                table: "Outdoors",
                newName: "IX_Outdoors_InvoiceID");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    Bill_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Due = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transaction_Info = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientID",
                table: "Invoices",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Outdoors_Invoices_InvoiceID",
                table: "Outdoors",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
