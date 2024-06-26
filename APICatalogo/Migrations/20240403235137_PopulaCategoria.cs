﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into categorias (Nome, ImagemUrl) Values ('Bebida', 'bebidas.jpg')");
            mb.Sql("Insert into categorias (Nome, ImagemUrl) Values ('Lanches', 'lanches.jpg')");
            mb.Sql("Insert into categorias (Nome, ImagemUrl) Values ('Sobremesas', 'sobremesas.jpg')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete From categorias");
        }
    }
}
