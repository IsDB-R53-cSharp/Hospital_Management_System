using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class SP_Modify_Service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
    //        var procGetAllServices = @" 
    //            CREATE PROCEDURE GetAllServices
    //            AS
    //            BEGIN
    //            SELECT * FROM Services
    //            END

    //            ";
    //        var procGetServicesById = @"
    //            CREATE PROCEDURE ServicesGetById(@ServiceID int)
    //            AS
    //            BEGIN
	   //             SELECT * FROM Services WHERE ServiceID=@ServiceID
    //            END

    //        ";

    //        var procAddService = @"
    //           CREATE PROCEDURE AddServices
				//(
    //            @ServiceName VARCHAR(20),
    //            @ServiceCharge DECIMAL(10, 2))
    //            AS
    //            BEGIN
    //            INSERT INTO Services
	   //         (ServiceName,ServiceCharge)
    //             VALUES
    //            (@ServiceName,@ServiceCharge)
    //            END
    //             ";

    //        var procUpdateService = @"
    //        CREATE PROCEDURE UpdateServices
	   //     (   @ServiceID int,
    //            @ServiceName VARCHAR(20),
    //            @ServiceCharge DECIMAL(10, 2)
    //         )
    //        AS
    //        BEGIN
    //        UPDATE Services
    //        SET
	   //         ServiceName=@ServiceName,
	   //         ServiceCharge=@ServiceCharge
    //        WHERE
	   //         ServiceID=@ServiceID;
    //        END

    //        ";

    //        var procDeleteService = @"
    //        CREATE PROCEDURE DeleteServices (@ServiceID int)
    //        AS
    //        BEGIN
	   //         DELETE FROM Services WHERE ServiceID=@ServiceID
    //        END
    //        ";

    //        migrationBuilder.Sql(procGetAllServices);
    //        migrationBuilder.Sql(procGetServicesById);
    //        migrationBuilder.Sql(procAddService);
    //        migrationBuilder.Sql(procUpdateService);
    //        migrationBuilder.Sql(procDeleteService);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //var procGetAllServices = @"DROP PROCEDURE GetAllServices";
            //var procGetServicesById = @"DROP PROCEDURE ServicesGetById";
            //var procAddService = @"DROP PROCEDURE AddServices";
            //var procUpdateService = @"DROP PROCEDURE UpdateServices";
            //var procDeleteService = @"DROP PROCEDURE DeleteServices";

            //migrationBuilder.Sql(procGetAllServices);
            //migrationBuilder.Sql(procGetServicesById);
            //migrationBuilder.Sql(procAddService);
            //migrationBuilder.Sql(procUpdateService);
            //migrationBuilder.Sql(procDeleteService);
        }
    }
}
