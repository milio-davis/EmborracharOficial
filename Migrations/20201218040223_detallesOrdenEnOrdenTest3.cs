using Microsoft.EntityFrameworkCore.Migrations;

namespace emb.Migrations
{
    public partial class detallesOrdenEnOrdenTest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "DetallesOrden",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrden_CategoriaId",
                table: "DetallesOrden",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesOrden_Categorias_CategoriaId",
                table: "DetallesOrden",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesOrden_Categorias_CategoriaId",
                table: "DetallesOrden");

            migrationBuilder.DropIndex(
                name: "IX_DetallesOrden_CategoriaId",
                table: "DetallesOrden");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "DetallesOrden");
        }
    }
}
