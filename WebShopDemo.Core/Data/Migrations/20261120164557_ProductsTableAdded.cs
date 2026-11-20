using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopDemo.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductsTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Primary key"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Product name"),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, comment: "Product price"),
                    quantity = table.Column<int>(type: "integer", nullable: false, comment: "Products in stock")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                },
                comment: "Profuct to sell");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
