using Microsoft.EntityFrameworkCore.Migrations;

namespace emb.Migrations
{
    public partial class quitarCarrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.AlterColumn<string>(
                name: "CarritoId",
                table: "ItemsCarrito",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CarritoId",
                table: "ItemsCarrito",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Carrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
