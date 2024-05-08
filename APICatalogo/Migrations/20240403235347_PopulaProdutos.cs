﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Values('Coca-Cola Diet', 'Refrigerante de Cola 350ml', 5.45, 'coca.jpg', 50, now(),2)");

            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Values('Lanche de atum', 'Lanche de Atum com maionese', 8.50, 'atum.jpg', 10, now(),3)");

            mb.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "Values('Pudim', 'Pudim de leite condensado 100g', 6.75, 'pudim.jpg', 20, now(),4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from produtos");
        }
    }
}