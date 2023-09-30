using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class medicineEmran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Manufacturer_ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineGeneric_MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineGeneric",
                table: "MedicineGeneric");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer");

            migrationBuilder.RenameTable(
                name: "MedicineGeneric",
                newName: "MedicineGenerics");

            migrationBuilder.RenameTable(
                name: "Manufacturer",
                newName: "Manufacturers");

            migrationBuilder.AddColumn<int>(
                name: "MedicineType",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineGenerics",
                table: "MedicineGenerics",
                column: "MedicineGenericID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Manufacturers_ManufacturerID",
                table: "Medicines",
                column: "ManufacturerID",
                principalTable: "Manufacturers",
                principalColumn: "ManufacturerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineGenerics_MedicineGenericID",
                table: "Medicines",
                column: "MedicineGenericID",
                principalTable: "MedicineGenerics",
                principalColumn: "MedicineGenericID",
                onDelete: ReferentialAction.Cascade);
            string GAllMedicines = @"create proc SpGetAllMedicine 
            as
            BEGIN
            select * FROM Medicines
            END";
            string GeMedicineById = @"create proc SphMedicineById(@id int) 
                as
                BEGIN
            select * FROM Medicines where MedicineID= @id
            END";
            string PoMedicine = @"create proc SpPtAllMedicine (  
        @MedicineName NVARCHAR(max),
        @Weight NVARCHAR(max),             
        @MedicineType INT,
        @DosageForms INT,
        @ExpireDate DATETIME,
        @Quantity INT,
        @SellPrice DECIMAL(10,2),
        @Discount DECIMAL(10,2),
        @MedicineGenericID INT,
        @ManufacturerID INT)
		as 
		BEGIN
			INSERT INTO Medicines
                (
                 MedicineName, Weight, MedicineType,DosageForms, ExpireDate, Quantity, SellPrice, Discount,MedicineGenericID,ManufacturerID)
                    VALUES     ( 
                  @MedicineName, @Weight, @MedicineType, @DosageForms,@ExpireDate, @Quantity, @SellPrice, @Discount,@MedicineGenericID,@ManufacturerID)
	END";
            string UpMedicine = @"create proc SpUdateMedicine (@id int,
               @MedicineName NVARCHAR(max),
                @Weight NVARCHAR(max),                     
        @MedicineType INT,
         @DosageForms INT,
       @ExpireDate DATE,
       @Quantity INT,
        @SellPrice DECIMAL(10,2),
      @Discount DECIMAL(10,2),
      @MedicineGenericID INT,
      @ManufacturerID INT)
								  as 
								  BEGIN
        UPDATE Medicines
        SET    MedicineName=@MedicineName,
                Weight=@Weight,			                  
	            MedicineType=@MedicineType,
                DosageForms=@DosageForms,
	            ExpireDate=@ExpireDate,
	            Quantity=@Quantity,
	            SellPrice=@SellPrice,
	            Discount=@Discount,
	           MedicineGenericID=@MedicineGenericID,
	            ManufacturerID=@ManufacturerID
        WHERE  MedicineID = @id
        END";
            string DeMedicine = @"create proc SpDeMedicine (@id int)
        as
        BEGIN
        DELETE FROM Medicines
        WHERE  MedicineID = @id
        END";
            migrationBuilder.Sql(GAllMedicines);
            migrationBuilder.Sql(GeMedicineById);
            migrationBuilder.Sql(PoMedicine);
            migrationBuilder.Sql(UpMedicine);
            migrationBuilder.Sql(DeMedicine);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Manufacturers_ManufacturerID",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineGenerics_MedicineGenericID",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineGenerics",
                table: "MedicineGenerics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "MedicineType",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "Medicines");

            migrationBuilder.RenameTable(
                name: "MedicineGenerics",
                newName: "MedicineGeneric");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "Manufacturer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineGeneric",
                table: "MedicineGeneric",
                column: "MedicineGenericID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturer",
                table: "Manufacturer",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Manufacturer_ManufacturerID",
                table: "Medicines",
                column: "ManufacturerID",
                principalTable: "Manufacturer",
                principalColumn: "ManufacturerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineGeneric_MedicineGenericID",
                table: "Medicines",
                column: "MedicineGenericID",
                principalTable: "MedicineGeneric",
                principalColumn: "MedicineGenericID",
                onDelete: ReferentialAction.Cascade);
            string GAllMedicines = @"Drop proc SpGetAllMedicine";
            string GeMedicineById = @"Drop proc SphMedicineById";
            string PoMedicine = @"Drop proc SpPtAllMedicine";
            string UpMedicine = @"Drop proc SpUdateMedicine";
            string DeMedicine = @"Drop proc SpDeMedicine";

            migrationBuilder.Sql(GAllMedicines);
            migrationBuilder.Sql(GeMedicineById);
            migrationBuilder.Sql(PoMedicine);
            migrationBuilder.Sql(UpMedicine);
            migrationBuilder.Sql(DeMedicine);
        }
    }
}
