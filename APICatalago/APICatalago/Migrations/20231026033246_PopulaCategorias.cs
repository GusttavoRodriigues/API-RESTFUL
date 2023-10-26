using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalago.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {

            mb.Sql("Insert into Categorias select 'Bebidas','bebidas.jpg'");
            mb.Sql("Insert into Categorias select 'Lanches','lanches.jpg'");
            mb.Sql("Insert into Categorias select 'Sobremesas','sobremesas.jpg'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE from Categorias");
        }
    }
}
