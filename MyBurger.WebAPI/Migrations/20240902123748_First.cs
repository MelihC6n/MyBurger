using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBurger.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingrediants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderedMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedMenus_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BR_Menu_Product",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BR_Menu_Product", x => new { x.MenuId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BR_Menu_Product_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BR_Menu_Product_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BR_Product_Ingrediant",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngrediantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BR_Product_Ingrediant", x => new { x.IngrediantId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BR_Product_Ingrediant_Ingrediants_IngrediantId",
                        column: x => x.IngrediantId,
                        principalTable: "Ingrediants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BR_Product_Ingrediant_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedMenuProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderedMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedMenuProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedMenuProducts_OrderedMenus_OrderedMenuId",
                        column: x => x.OrderedMenuId,
                        principalTable: "OrderedMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedMenuProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnorderedIngrediants",
                columns: table => new
                {
                    OrderedMenuProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngrediantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnorderedIngrediants", x => new { x.IngrediantId, x.OrderedMenuProductId });
                    table.ForeignKey(
                        name: "FK_UnorderedIngrediants_Ingrediants_IngrediantId",
                        column: x => x.IngrediantId,
                        principalTable: "Ingrediants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnorderedIngrediants_OrderedMenuProducts_OrderedMenuProductId",
                        column: x => x.OrderedMenuProductId,
                        principalTable: "OrderedMenuProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BR_Menu_Product_ProductId",
                table: "BR_Menu_Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BR_Product_Ingrediant_ProductId",
                table: "BR_Product_Ingrediant",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedMenuProducts_OrderedMenuId",
                table: "OrderedMenuProducts",
                column: "OrderedMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedMenuProducts_ProductId",
                table: "OrderedMenuProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedMenus_MenuId",
                table: "OrderedMenus",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedMenus_OrderId",
                table: "OrderedMenus",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UnorderedIngrediants_OrderedMenuProductId",
                table: "UnorderedIngrediants",
                column: "OrderedMenuProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BR_Menu_Product");

            migrationBuilder.DropTable(
                name: "BR_Product_Ingrediant");

            migrationBuilder.DropTable(
                name: "UnorderedIngrediants");

            migrationBuilder.DropTable(
                name: "Ingrediants");

            migrationBuilder.DropTable(
                name: "OrderedMenuProducts");

            migrationBuilder.DropTable(
                name: "OrderedMenus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
