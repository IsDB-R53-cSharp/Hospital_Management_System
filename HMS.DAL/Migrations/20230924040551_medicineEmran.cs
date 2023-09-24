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
            string GAllMedicine = @"create proc SpAllMedicine 
		as
		BEGIN
            select * FROM Medicines
        END";
            string GMedicineById = @"create proc SpMedicineById(@id int) 
		        as
		        BEGIN
                    select * FROM Medicines where MedicineID= @id
                END";
            string PMedicine = @"create proc SpPostMedicine (  
                @MedicineName NVARCHAR(max),
                @Strength INT,
                @MedicineType INT,
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
                         MedicineName, Strength, MedicineType, ExpireDate, Quantity, SellPrice, Discount,MedicineGenericID,ManufacturerID)
                            VALUES     ( 
                          @MedicineName, @Strength, @MedicineType, @ExpireDate, @Quantity, @SellPrice, @Discount,@MedicineGenericID,@ManufacturerID)
			END";
            string UMedicine = @"create proc SpUpdateMedicine (@id int,
                       @MedicineName NVARCHAR(max),
                @Strength INT,
                @MedicineType INT,
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
			                  Strength=@Strength,
			                  MedicineType=@MedicineType,
			                   ExpireDate=@ExpireDate,
			                    Quantity=@Quantity,
			                    SellPrice=@SellPrice,
			                    Discount=@Discount,
			                   MedicineGenericID=@MedicineGenericID,
			                    ManufacturerID=@ManufacturerID
                WHERE  MedicineID = @id
                END";
            string DMedicine = @"create proc SpDeleteMedicine (@id int)
                as
                BEGIN
                DELETE FROM Medicines
                WHERE  MedicineID = @id
                END";
            migrationBuilder.Sql(GAllMedicine);
            migrationBuilder.Sql(GMedicineById);
            migrationBuilder.Sql(PMedicine);
            migrationBuilder.Sql(UMedicine);
            migrationBuilder.Sql(DMedicine);
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
            string GAllMedicine = @"Drop proc SpAllMedicine";
            string GMedicineById = @"Drop proc SpMedicineById";
            string PMedicine = @"Drop proc SpPostMedicine";
            string UMedicine = @"Drop proc SpUpdateMedicine";
            string DMedicine = @"Drop proc SpDeleteMedicine";

            migrationBuilder.Sql(GAllMedicine);
            migrationBuilder.Sql(GMedicineById);
            migrationBuilder.Sql(PMedicine);
            migrationBuilder.Sql(UMedicine);
            migrationBuilder.Sql(DMedicine);
        }
    }
}
