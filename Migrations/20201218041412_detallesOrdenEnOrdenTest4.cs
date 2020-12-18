using Microsoft.EntityFrameworkCore.Migrations;

namespace emb.Migrations
{
    public partial class detallesOrdenEnOrdenTest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrden_Categorias_CategoriaId",
                table: "DetallesOrden");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DetallesOrden",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrden_Categorias_CategoriaId",
                table: "DetallesOrden",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrden_Categorias_CategoriaId",
                table: "DetallesOrden");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "DetallesOrden",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrden_Categorias_CategoriaId",
                table: "DetallesOrden",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
