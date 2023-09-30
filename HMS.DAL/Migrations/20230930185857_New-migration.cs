using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advices",
                columns: table => new
                {
                    AdviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdviceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advices", x => x.AdviceId);
                });

            migrationBuilder.CreateTable(
                name: "Ambulances",
                columns: table => new
                {
                    AmbulanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmbulanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.AmbulanceID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodBanks",
                columns: table => new
                {
                    BloodBankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBanks", x => x.BloodBankID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "DischargeTransfers",
                columns: table => new
                {
                    DT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeSummary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeTransfers", x => x.DT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Dosage",
                columns: table => new
                {
                    DosageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosage", x => x.DosageID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineGenerics",
                columns: table => new
                {
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineGenericNames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineGenerics", x => x.MedicineGenericID);
                });

            migrationBuilder.CreateTable(
                name: "Morgues",
                columns: table => new
                {
                    MorgueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MorgueName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsolationCapability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morgues", x => x.MorgueID);
                });

            migrationBuilder.CreateTable(
                name: "PatientRegisters",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRegisters", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "PreoperativeDiagnoses",
                columns: table => new
                {
                    PreoperativeDiagnosisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreoperativeDiagnosisName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreoperativeDiagnoses", x => x.PreoperativeDiagnosisID);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    SymptomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymptomName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.SymptomId);
                });

            migrationBuilder.CreateTable(
                name: "TotalBills",
                columns: table => new
                {
                    TotalBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    PreparedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalBills", x => x.TotalBillID);
                });

            migrationBuilder.CreateTable(
                name: "unidentifiedDeadBodies",
                columns: table => new
                {
                    UnIdenfiedDeadBodyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<int>(type: "int", nullable: false),
                    DeceasedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "date", nullable: true),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidentifiedDeadBodies", x => x.UnIdenfiedDeadBodyID);
                });

            migrationBuilder.CreateTable(
                name: "WasteManagements",
                columns: table => new
                {
                    WasteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WasteType = table.Column<int>(type: "int", nullable: false),
                    DisposalDate = table.Column<DateTime>(type: "date", nullable: false),
                    DisposalMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NextScheduleDate = table.Column<DateTime>(type: "date", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteManagements", x => x.WasteID);
                });

            migrationBuilder.CreateTable(
                name: "OtherEmployees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherEmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OtherEmployeeType = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmbulanceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEmployees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_OtherEmployees_Ambulances_AmbulanceID",
                        column: x => x.AmbulanceID,
                        principalTable: "Ambulances",
                        principalColumn: "AmbulanceID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Doctortype = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabTechnicians",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    TechnicianType = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTechnicians", x => x.TechnicianID);
                    table.ForeignKey(
                        name: "FK_LabTechnicians_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    NurseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    NurseLevel = table.Column<int>(type: "int", nullable: false),
                    NurseType = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.NurseID);
                    table.ForeignKey(
                        name: "FK_Nurses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WardCabins",
                columns: table => new
                {
                    WardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardCabinName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardCabins", x => x.WardID);
                    table.ForeignKey(
                        name: "FK_WardCabins_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    DrawerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrawerCondition = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "MedicineBills",
                columns: table => new
                {
                    MedicineBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    MB_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBills", x => x.MedicineBillID);
                    table.ForeignKey(
                        name: "FK_MedicineBills_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicineBills_TotalBills_TotalBillID",
                        column: x => x.TotalBillID,
                        principalTable: "TotalBills",
                        principalColumn: "TotalBillID");
                });

            migrationBuilder.CreateTable(
                name: "Outdoors",
                columns: table => new
                {
                    OutdoorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    TreatmentType = table.Column<int>(type: "int", nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmissionRequired = table.Column<bool>(type: "bit", nullable: false),
                    TotalBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outdoors", x => x.OutdoorID);
                    table.ForeignKey(
                        name: "FK_Outdoors_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_Outdoors_TotalBills_TotalBillID",
                        column: x => x.TotalBillID,
                        principalTable: "TotalBills",
                        principalColumn: "TotalBillID");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionBills",
                columns: table => new
                {
                    PrescriptionBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    PB_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientRegistersPatientID = table.Column<int>(type: "int", nullable: false),
                    TotalBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionBills", x => x.PrescriptionBillID);
                    table.ForeignKey(
                        name: "FK_PrescriptionBills_PatientRegisters_PatientRegistersPatientID",
                        column: x => x.PatientRegistersPatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrescriptionBills_TotalBills_TotalBillID",
                        column: x => x.TotalBillID,
                        principalTable: "TotalBills",
                        principalColumn: "TotalBillID");
                });

            migrationBuilder.CreateTable(
                name: "ServiceBills",
                columns: table => new
                {
                    ServiceBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCount = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    SB_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBills", x => x.ServiceBillID);
                    table.ForeignKey(
                        name: "FK_ServiceBills_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceBills_TotalBills_TotalBillID",
                        column: x => x.TotalBillID,
                        principalTable: "TotalBills",
                        principalColumn: "TotalBillID");
                });

            migrationBuilder.CreateTable(
                name: "TestBills",
                columns: table => new
                {
                    TestBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    TB_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientRegistersPatientID = table.Column<int>(type: "int", nullable: false),
                    TotalBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestBills", x => x.TestBillID);
                    table.ForeignKey(
                        name: "FK_TestBills_PatientRegisters_PatientRegistersPatientID",
                        column: x => x.PatientRegistersPatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestBills_TotalBills_TotalBillID",
                        column: x => x.TotalBillID,
                        principalTable: "TotalBills",
                        principalColumn: "TotalBillID");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LabTechnicianTechnicianID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestID);
                    table.ForeignKey(
                        name: "FK_Tests_LabTechnicians_LabTechnicianTechnicianID",
                        column: x => x.LabTechnicianTechnicianID,
                        principalTable: "LabTechnicians",
                        principalColumn: "TechnicianID");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    OutdoorID = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false),
                    NurseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "NurseID");
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    WardCabinID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedID);
                    table.ForeignKey(
                        name: "FK_Beds_WardCabins_WardCabinID",
                        column: x => x.WardCabinID,
                        principalTable: "WardCabins",
                        principalColumn: "WardID");
                });

            migrationBuilder.CreateTable(
                name: "DrawersInfo",
                columns: table => new
                {
                    DrawerInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    DrawerID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    UnidentifiedDeadBodyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawersInfo", x => x.DrawerInfoID);
                    table.ForeignKey(
                        name: "FK_DrawersInfo_Drawers_DrawerID",
                        column: x => x.DrawerID,
                        principalTable: "Drawers",
                        principalColumn: "DrawerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawersInfo_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_DrawersInfo_unidentifiedDeadBodies_UnidentifiedDeadBodyID",
                        column: x => x.UnidentifiedDeadBodyID,
                        principalTable: "unidentifiedDeadBodies",
                        principalColumn: "UnIdenfiedDeadBodyID");
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineType = table.Column<int>(type: "int", nullable: false),
                    DosageForms = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false),
                    MedicineBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineID);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineBills_MedicineBillID",
                        column: x => x.MedicineBillID,
                        principalTable: "MedicineBills",
                        principalColumn: "MedicineBillID");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OutdoorID = table.Column<int>(type: "int", nullable: true),
                    ServiceBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Services_Outdoors_OutdoorID",
                        column: x => x.OutdoorID,
                        principalTable: "Outdoors",
                        principalColumn: "OutdoorID");
                    table.ForeignKey(
                        name: "FK_Services_ServiceBills_ServiceBillID",
                        column: x => x.ServiceBillID,
                        principalTable: "ServiceBills",
                        principalColumn: "ServiceBillID");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    MedicinID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    SymptomId = table.Column<int>(type: "int", nullable: false),
                    AdviceId = table.Column<int>(type: "int", nullable: false),
                    DosageID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProgressNotes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NextVisit = table.Column<DateTime>(type: "date", nullable: true),
                    AdmissionSuggested = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpInstructions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NurseID = table.Column<int>(type: "int", nullable: true),
                    PrescriptionBillID = table.Column<int>(type: "int", nullable: true),
                    TestBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Advices_AdviceId",
                        column: x => x.AdviceId,
                        principalTable: "Advices",
                        principalColumn: "AdviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Dosage_DosageID",
                        column: x => x.DosageID,
                        principalTable: "Dosage",
                        principalColumn: "DosageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "NurseID");
                    table.ForeignKey(
                        name: "FK_Prescriptions_PrescriptionBills_PrescriptionBillID",
                        column: x => x.PrescriptionBillID,
                        principalTable: "PrescriptionBills",
                        principalColumn: "PrescriptionBillID");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Symptoms_SymptomId",
                        column: x => x.SymptomId,
                        principalTable: "Symptoms",
                        principalColumn: "SymptomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_TestBills_TestBillID",
                        column: x => x.TestBillID,
                        principalTable: "TestBills",
                        principalColumn: "TestBillID");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetail",
                columns: table => new
                {
                    ReportDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetail", x => x.ReportDetailID);
                    table.ForeignKey(
                        name: "FK_ReportDetail_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndoorPatients",
                columns: table => new
                {
                    IndoorPatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferredBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BedID = table.Column<int>(type: "int", nullable: false),
                    InsuranceInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AdmissionNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDead = table.Column<bool>(type: "bit", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordsID = table.Column<int>(type: "int", nullable: true),
                    NIDnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "date", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: true),
                    IsTransferred = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndoorPatients", x => x.IndoorPatientID);
                    table.ForeignKey(
                        name: "FK_IndoorPatients_Beds_BedID",
                        column: x => x.BedID,
                        principalTable: "Beds",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedicalRecordsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientType = table.Column<bool>(type: "bit", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    PrescriptionID = table.Column<int>(type: "int", nullable: true),
                    TestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordsID);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID");
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID");
                });

            migrationBuilder.CreateTable(
                name: "Surgeries",
                columns: table => new
                {
                    SurgeryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    SurgeryType = table.Column<int>(type: "int", nullable: false),
                    SurgeryDate = table.Column<DateTime>(type: "date", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Preoperative_Diagnosis = table.Column<int>(type: "int", nullable: false),
                    Postoperative_Diagnosis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    NurseID = table.Column<int>(type: "int", nullable: true),
                    PreoperativeDiagnosisID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgeries", x => x.SurgeryID);
                    table.ForeignKey(
                        name: "FK_Surgeries_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Surgeries_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "NurseID");
                    table.ForeignKey(
                        name: "FK_Surgeries_PreoperativeDiagnoses_PreoperativeDiagnosisID",
                        column: x => x.PreoperativeDiagnosisID,
                        principalTable: "PreoperativeDiagnoses",
                        principalColumn: "PreoperativeDiagnosisID");
                    table.ForeignKey(
                        name: "FK_Surgeries_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Surgeries_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestReports",
                columns: table => new
                {
                    TestReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDetailID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestReports", x => x.TestReportID);
                    table.ForeignKey(
                        name: "FK_TestReports_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestReports_ReportDetail_ReportDetailID",
                        column: x => x.ReportDetailID,
                        principalTable: "ReportDetail",
                        principalColumn: "ReportDetailID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionBills",
                columns: table => new
                {
                    AdmissionBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndoorPatientID = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    AB_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionBills", x => x.AdmissionBillID);
                    table.ForeignKey(
                        name: "FK_AdmissionBills_IndoorPatients_IndoorPatientID",
                        column: x => x.IndoorPatientID,
                        principalTable: "IndoorPatients",
                        principalColumn: "IndoorPatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdmissionBills_TotalBills_TotalBillID",
                        column: x => x.TotalBillID,
                        principalTable: "TotalBills",
                        principalColumn: "TotalBillID");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentDescription", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "It is concerned with disorders and diseases of the nervous system", "Neurology" },
                    { 2, "The branch of medicine dealing with children and their diseases.", "Paediatrics" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerID", "ManufacturerName" },
                values: new object[,]
                {
                    { 1, "Square Pharmaceuticals Ltd " },
                    { 2, "Incepta Pharmaceutical Ltd" },
                    { 3, "Beximco Pharmaceuticals Ltd" },
                    { 4, "Opsonin Pharma Ltd" },
                    { 5, "Renata Ltd" },
                    { 6, "Healthcare Pharmaceuticals Ltd" },
                    { 7, "Radient Pharmaceuticals Ltd" },
                    { 8, "Eskayef Pharmaceuticals Ltd" },
                    { 9, "ACME Laboratories Ltd" },
                    { 10, "Aristopharma Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineID", "Discount", "DosageForms", "ExpireDate", "ManufacturerID", "MedicineBillID", "MedicineGenericID", "MedicineName", "MedicineType", "Quantity", "SellPrice", "Weight" },
                values: new object[,]
                {
                    { 1, 50.00m, 2, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, "Napa", 1, 522, 5612.00m, "500mg" },
                    { 2, 50.00m, 2, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 2, "Seclo", 1, 522, 5612.00m, "20mg" },
                    { 3, 50.00m, 2, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 2, "Napa Extra", 1, 522, 5612.00m, "20mg" }
                });

            migrationBuilder.InsertData(
                table: "OtherEmployees",
                columns: new[] { "EmployeeID", "AmbulanceID", "Education_Info", "Image", "JoinDate", "OtherEmployeeName", "OtherEmployeeType", "PhoneNumber", "ResignDate", "employeeStatus" },
                values: new object[,]
                {
                    { 1, null, "JSC", "wordboy1.jpg", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "abul mia", 2, "01917123456", null, 1 },
                    { 2, null, "SSC", "driver1.jpg", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ataur", 6, "01517123456", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "PatientRegisters",
                columns: new[] { "PatientID", "Address", "Email", "Gender", "PatientName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "dhaka", "am@gmail.com", 2, "Sultana begum", "12345678" },
                    { 2, "Sirajgonj", "az@gmail.com", 1, "Azman Mollah", "1233454" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "OutdoorID", "ServiceBillID", "ServiceCharge", "ServiceName" },
                values: new object[,]
                {
                    { 1, null, null, 500m, "Bed charge" },
                    { 2, null, null, 1500m, "Cabin charge" },
                    { 3, null, null, 3000m, "ICU charge" },
                    { 4, null, null, 120m, "Oxygen charge (per liter)" },
                    { 5, null, null, 200m, "Food (per time)" },
                    { 6, null, null, 100m, "Wound Dressing" },
                    { 7, null, null, 50m, "Injection Pushing" },
                    { 8, null, null, 500m, "Outdoor Doctor Visit" },
                    { 9, null, null, 800m, "Indoor Doctor Visit (Assistant Professor)" },
                    { 10, null, null, 1200m, "Indoor Doctor Visit (Associate Professor)" },
                    { 11, null, null, 1500m, "Indoor Doctor Visit (Professor)" },
                    { 12, null, null, 100m, "Room Cleaning" },
                    { 13, null, null, 50m, "Patient Cleaning" },
                    { 14, null, null, 300m, "Physical Therapy" },
                    { 15, null, null, 1000m, "Ambulance charge" },
                    { 16, null, null, 500m, "Morgue charge" },
                    { 17, null, null, 100m, "Cloth Fee (Hospital Gown)" },
                    { 18, null, null, 250m, "Orthopedic Device charge (crutches, wheelchair)" },
                    { 19, null, null, 200m, "Pathological Sample Collection Fee (from Bed/Home)" },
                    { 20, null, null, 400m, "Counseling fee" },
                    { 21, null, null, 400m, "Rehabilitation fee" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "DepartmentID", "DoctorName", "Doctortype", "Education_Info", "Image", "JoinDate", "PhoneNumber", "ResignDate", "Specialization", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Pipul Rahman", 1, "MD in Cardiology from DMC University", "doctor1.jpg", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01917123456", null, "Cardiologist", 1 },
                    { 2, 2, "Ass Pina", 4, "MD in Orthopedics from ABC University", "doctor2.jpg", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01517123456", null, "Orthopedic Surgeon", 1 }
                });

            migrationBuilder.InsertData(
                table: "LabTechnicians",
                columns: new[] { "TechnicianID", "DepartmentID", "Education_Info", "Image", "JoinDate", "PhoneNumber", "ResignDate", "TechnicianName", "TechnicianType", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Bachelor of Science in Medical Technology", "labtech1.jpg", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01617123456", null, "valsun choudhury", 1, 1 },
                    { 2, 2, "Certified Laboratory Technician", "labtech2.jpg", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01917123456", null, "Robin mia", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "NurseID", "DepartmentID", "Education_Info", "Image", "JoinDate", "NurseLevel", "NurseName", "NurseType", "PhoneNumber", "ResignDate", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Bachelor of Science in Nursing", "nurse1.jpg", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sharmin Jahan", 1, "01317123456", null, 1 },
                    { 2, 2, "Licensed Practical Nurse Certification", "nurse2.jpg", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Hafsa khatun", 2, "01817123456", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "DepartmentID", "WardCabinName" },
                values: new object[,]
                {
                    { 1, 1, "Neuro Care" },
                    { 2, 2, "Child Care" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionBills_IndoorPatientID",
                table: "AdmissionBills",
                column: "IndoorPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionBills_TotalBillID",
                table: "AdmissionBills",
                column: "TotalBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_NurseID",
                table: "Appointments",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_WardCabinID",
                table: "Beds",
                column: "WardCabinID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentID",
                table: "Doctors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_MorgueID",
                table: "Drawers",
                column: "MorgueID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_DrawerID",
                table: "DrawersInfo",
                column: "DrawerID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_PatientID",
                table: "DrawersInfo",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_UnidentifiedDeadBodyID",
                table: "DrawersInfo",
                column: "UnidentifiedDeadBodyID");

            migrationBuilder.CreateIndex(
                name: "IX_IndoorPatients_BedID",
                table: "IndoorPatients",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTechnicians_DepartmentID",
                table: "LabTechnicians",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PrescriptionID",
                table: "MedicalRecords",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_TestID",
                table: "MedicalRecords",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineBills_PatientID",
                table: "MedicineBills",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineBills_TotalBillID",
                table: "MedicineBills",
                column: "TotalBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineBillID",
                table: "Medicines",
                column: "MedicineBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_DepartmentID",
                table: "Nurses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherEmployees_AmbulanceID",
                table: "OtherEmployees",
                column: "AmbulanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Outdoors_PatientID",
                table: "Outdoors",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Outdoors_TotalBillID",
                table: "Outdoors",
                column: "TotalBillID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionBills_PatientRegistersPatientID",
                table: "PrescriptionBills",
                column: "PatientRegistersPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionBills_TotalBillID",
                table: "PrescriptionBills",
                column: "TotalBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_AdviceId",
                table: "Prescriptions",
                column: "AdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorID",
                table: "Prescriptions",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DosageID",
                table: "Prescriptions",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_NurseID",
                table: "Prescriptions",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PrescriptionBillID",
                table: "Prescriptions",
                column: "PrescriptionBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_SymptomId",
                table: "Prescriptions",
                column: "SymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_TestBillID",
                table: "Prescriptions",
                column: "TestBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_TestID",
                table: "Prescriptions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetail_TestID",
                table: "ReportDetail",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBills_PatientID",
                table: "ServiceBills",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBills_TotalBillID",
                table: "ServiceBills",
                column: "TotalBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_OutdoorID",
                table: "Services",
                column: "OutdoorID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceBillID",
                table: "Services",
                column: "ServiceBillID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_DoctorID",
                table: "Surgeries",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_NurseID",
                table: "Surgeries",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_PreoperativeDiagnosisID",
                table: "Surgeries",
                column: "PreoperativeDiagnosisID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_PrescriptionID",
                table: "Surgeries",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_TestID",
                table: "Surgeries",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_TestBills_PatientRegistersPatientID",
                table: "TestBills",
                column: "PatientRegistersPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_TestBills_TotalBillID",
                table: "TestBills",
                column: "TotalBillID");

            migrationBuilder.CreateIndex(
                name: "IX_TestReports_PrescriptionID",
                table: "TestReports",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestReports_ReportDetailID",
                table: "TestReports",
                column: "ReportDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LabTechnicianTechnicianID",
                table: "Tests",
                column: "LabTechnicianTechnicianID");

            migrationBuilder.CreateIndex(
                name: "IX_WardCabins_DepartmentID",
                table: "WardCabins",
                column: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionBills");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BloodBanks");

            migrationBuilder.DropTable(
                name: "DischargeTransfers");

            migrationBuilder.DropTable(
                name: "DrawersInfo");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "MedicineGenerics");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "OtherEmployees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Surgeries");

            migrationBuilder.DropTable(
                name: "TestReports");

            migrationBuilder.DropTable(
                name: "WasteManagements");

            migrationBuilder.DropTable(
                name: "IndoorPatients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropTable(
                name: "unidentifiedDeadBodies");

            migrationBuilder.DropTable(
                name: "MedicineBills");

            migrationBuilder.DropTable(
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "Outdoors");

            migrationBuilder.DropTable(
                name: "ServiceBills");

            migrationBuilder.DropTable(
                name: "PreoperativeDiagnoses");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "ReportDetail");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Morgues");

            migrationBuilder.DropTable(
                name: "Advices");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Dosage");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "PrescriptionBills");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "TestBills");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "WardCabins");

            migrationBuilder.DropTable(
                name: "PatientRegisters");

            migrationBuilder.DropTable(
                name: "TotalBills");

            migrationBuilder.DropTable(
                name: "LabTechnicians");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
