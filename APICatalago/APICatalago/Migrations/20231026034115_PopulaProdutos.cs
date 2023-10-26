using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalago.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos select 'Coca-cola Diet','Refrigerante de Cola 350ml',5.45,'cocacola.jpg',50,GETDATE(),1");
            mb.Sql("Insert into Produtos select 'Lanche de Atum','Lanche de Atum com Maionese',8.50,'atum.jpg',10,GETDATE(),2");
            mb.Sql("Insert into Produtos select 'Pudim 100 g','Pudim de Leite Condensado 100g',6.75,'pudim.jpg',20,GETDATE(),3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos");
        }
    }
}
