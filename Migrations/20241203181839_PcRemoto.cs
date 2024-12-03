using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace burgermania_backend.Migrations
{
    /// <inheritdoc />
    public partial class PcRemoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId1",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId1",
                table: "Produtos",
                column: "CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId1",
                table: "Produtos",
                column: "CategoriaId1",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId1",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoriaId1",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "Produtos");
        }
    }
}
