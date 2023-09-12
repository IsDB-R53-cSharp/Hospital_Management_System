using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class newUpdateWithSeedValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambulances",
                columns: table => new
                {
                    AmbulanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmbulanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrivingLiense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.AmbulanceID);
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
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    Transaction_Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bill_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Due = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineGeneric",
                columns: table => new
                {
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineGenericNames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineGeneric", x => x.MedicineGenericID);
                });

            migrationBuilder.CreateTable(
                name: "Morgues",
                columns: table => new
                {
                    MorgueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeceasedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morgues", x => x.MorgueID);
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
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEmployees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "PatientRegisters",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "date", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodType = table.Column<int>(type: "int", nullable: true),
                    IsTransferred = table.Column<bool>(type: "bit", nullable: true),
                    WardID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRegisters", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "WasteManagements",
                columns: table => new
                {
                    WasteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WasteType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisposalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisposalMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NextScheduleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteManagements", x => x.WasteID);
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
                name: "LabEquipments",
                columns: table => new
                {
                    EquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabEquipments", x => x.EquipmentID);
                    table.ForeignKey(
                        name: "FK_LabEquipments_Departments_DepartmentID",
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
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    WardName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BedCabinNumber = table.Column<int>(type: "int", nullable: false),
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
                name: "Medicines",
                columns: table => new
                {
                    MedicineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineID);
                    table.ForeignKey(
                        name: "FK_Medicines_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicines_MedicineGeneric_MedicineGenericID",
                        column: x => x.MedicineGenericID,
                        principalTable: "MedicineGeneric",
                        principalColumn: "MedicineGenericID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outdoors",
                columns: table => new
                {
                    OutdoorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    TreatmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmissionRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outdoors", x => x.OutdoorID);
                    table.ForeignKey(
                        name: "FK_Outdoors_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outdoors_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianID = table.Column<int>(type: "int", nullable: false),
                    LabTechnicianTechnicianID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.TestID);
                    table.ForeignKey(
                        name: "FK_LabTests_LabTechnicians_LabTechnicianTechnicianID",
                        column: x => x.LabTechnicianTechnicianID,
                        principalTable: "LabTechnicians",
                        principalColumn: "TechnicianID");
                    table.ForeignKey(
                        name: "FK_LabTests_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentStatus = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    MedicinID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Advice = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProgressNotes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NextVisit = table.Column<DateTime>(type: "date", nullable: true),
                    AdmissionSuggested = table.Column<bool>(type: "bit", nullable: false),
                    DiagnosisDate = table.Column<DateTime>(type: "date", nullable: true),
                    Symptoms = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SymptomStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    Severity = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    DiagonesNotes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FollowUpInstructions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NurseID = table.Column<int>(type: "int", nullable: true),
                    PatientRegisterPatientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_LabTests_TestID",
                        column: x => x.TestID,
                        principalTable: "LabTests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "NurseID");
                    table.ForeignKey(
                        name: "FK_Prescriptions_PatientRegisters_PatientRegisterPatientID",
                        column: x => x.PatientRegisterPatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
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
                    LabTestTestID = table.Column<int>(type: "int", nullable: true),
                    PrescriptionsPrescriptionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordsID);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_LabTests_LabTestTestID",
                        column: x => x.LabTestTestID,
                        principalTable: "LabTests",
                        principalColumn: "TestID");
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Prescriptions_PrescriptionsPrescriptionID",
                        column: x => x.PrescriptionsPrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID");
                });

            migrationBuilder.CreateTable(
                name: "SurgeryProcedures",
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
                    PrescriptionsPrescriptionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurgeryProcedures", x => x.SurgeryID);
                    table.ForeignKey(
                        name: "FK_SurgeryProcedures_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurgeryProcedures_LabTests_TestID",
                        column: x => x.TestID,
                        principalTable: "LabTests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurgeryProcedures_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "NurseID");
                    table.ForeignKey(
                        name: "FK_SurgeryProcedures_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurgeryProcedures_Prescriptions_PrescriptionsPrescriptionID",
                        column: x => x.PrescriptionsPrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID");
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
                table: "PatientRegisters",
                columns: new[] { "PatientID", "Address", "AdmissionDate", "BloodType", "DateOfBirth", "Email", "EmergencyContact", "Gender", "IsTransferred", "PatientName", "Phone", "WardID" },
                values: new object[,]
                {
                    { 1, "dhaka", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1999, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "am@gmail.com", "123456789", 2, false, "amina begum", "12345678", 1 },
                    { 2, "Pabna", new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(1971, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "az@gmail.com", "123456789", 1, false, "Azman Mollah", "1233454", 3 }
                });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "BedCabinNumber", "DepartmentID", "WardName" },
                values: new object[] { 1, 23, 1, "Neuro Care" });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "BedCabinNumber", "DepartmentID", "WardName" },
                values: new object[] { 2, 40, 2, "Child Care" });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "BedCabinNumber", "DepartmentID", "WardName" },
                values: new object[] { 3, 12, 1, "Nerve Care" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_NurseID",
                table: "Appointments",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentID",
                table: "Doctors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LabEquipments_DepartmentID",
                table: "LabEquipments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTechnicians_DepartmentID",
                table: "LabTechnicians",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_LabTechnicianTechnicianID",
                table: "LabTests",
                column: "LabTechnicianTechnicianID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_PatientID",
                table: "LabTests",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_LabTestTestID",
                table: "MedicalRecords",
                column: "LabTestTestID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PrescriptionsPrescriptionID",
                table: "MedicalRecords",
                column: "PrescriptionsPrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_ManufacturerID",
                table: "Medicines",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineGenericID",
                table: "Medicines",
                column: "MedicineGenericID");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_DepartmentID",
                table: "Nurses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Outdoors_InvoiceID",
                table: "Outdoors",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Outdoors_PatientID",
                table: "Outdoors",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorID",
                table: "Prescriptions",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_NurseID",
                table: "Prescriptions",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientRegisterPatientID",
                table: "Prescriptions",
                column: "PatientRegisterPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_TestID",
                table: "Prescriptions",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_DoctorID",
                table: "SurgeryProcedures",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_NurseID",
                table: "SurgeryProcedures",
                column: "NurseID");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_PrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_PrescriptionsPrescriptionID",
                table: "SurgeryProcedures",
                column: "PrescriptionsPrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_SurgeryProcedures_TestID",
                table: "SurgeryProcedures",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_WardCabins_DepartmentID",
                table: "WardCabins",
                column: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "BloodBanks");

            migrationBuilder.DropTable(
                name: "DischargeTransfers");

            migrationBuilder.DropTable(
                name: "LabEquipments");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Morgues");

            migrationBuilder.DropTable(
                name: "OtherEmployees");

            migrationBuilder.DropTable(
                name: "Outdoors");

            migrationBuilder.DropTable(
                name: "SurgeryProcedures");

            migrationBuilder.DropTable(
                name: "WardCabins");

            migrationBuilder.DropTable(
                name: "WasteManagements");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "MedicineGeneric");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "LabTechnicians");

            migrationBuilder.DropTable(
                name: "PatientRegisters");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
