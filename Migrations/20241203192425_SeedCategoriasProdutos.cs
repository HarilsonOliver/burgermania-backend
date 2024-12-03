using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace burgermania_backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoriasProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descricao", "Nome", "PathImage" },
                values: new object[,]
                {
                    { 1, "Para os amantes da vida animal.", "X-Vegan", "/burgersCat.png" },
                    { 2, "Vestuário e acessórios", "X-Fitness", "/burgersCat.png" },
                    { 3, "Comidas e bebidas", "X-Infarto", "/burgersCat.png" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "CategoriaId1", "DescricaoBase", "DescricaoInteira", "Nome", "PathImage", "Preco" },
                values: new object[,]
                {
                    { 1, 1, null, "Simples e Saudável", "Constituido apenas de folhas frescas, Pão, blend de soja e azeite.", "X-Salada", "/burgersCat.png", 20.00m },
                    { 2, 2, null, "Proteinado", "Contem Pão, Queijos, Blend de Carnes Vermelhas e Brancas, Molho de Whey e Adicional do Suco. ", "X-Whey", "/burgersCat.png", 50.00m },
                    { 3, 3, null, "Chama o  SAMU", "Pão  frito, Hamburger frito, Bacon frito e torrado, ovo frito, cebola frita e maionese temperada.", "X-Bacon Torrado", "/burgersCat.png", 80.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
