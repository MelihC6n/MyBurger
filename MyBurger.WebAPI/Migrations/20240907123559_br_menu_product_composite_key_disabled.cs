using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBurger.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class br_menu_product_composite_key_disabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BR_Menu_Product",
                table: "BR_Menu_Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BR_Menu_Product",
                table: "BR_Menu_Product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BR_Menu_Product_MenuId",
                table: "BR_Menu_Product",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BR_Menu_Product",
                table: "BR_Menu_Product");

            migrationBuilder.DropIndex(
                name: "IX_BR_Menu_Product_MenuId",
                table: "BR_Menu_Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BR_Menu_Product",
                table: "BR_Menu_Product",
                columns: new[] { "MenuId", "ProductId" });
        }
    }
}
