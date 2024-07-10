using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alerium.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StoreProcedureDeleteProveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE PROCEDURE sp_DeleteProveedorIfProductoNotExist
            (
                @proveedorId UNIQUEIDENTIFIER = NULL,
            	@deleteProveedor INT OUTPUT
            )
            AS
            BEGIN
            
            	DECLARE @intProducts int;
            
            	SET NOCOUNT ON
            
            	SET @intProducts = (SELECT COUNT(p2.Id) FROM Proveedores AS p1 
            		INNER JOIN Productos AS p2 ON p1.Id = p2.ProveedoresId WHERE P2.ProveedoresId = @proveedorId);
            	
            	IF @intProducts = 0
            	BEGIN
            		DELETE FROM Proveedores WHERE Proveedores.id = @proveedorId;
            		SET @deleteProveedor = 1;
            	END;
            	ELSE
            		SET @deleteProveedor = 0;
            
            	RETURN @deleteProveedor;
            END; 
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE sp_DeleteProveedorIfProductoNotExist");
        }
    }
}
