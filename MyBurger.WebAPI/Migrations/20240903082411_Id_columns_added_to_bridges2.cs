using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBurger.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Id_columns_added_to_bridges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BR_Product_Ingrediant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BR_Product_Ingrediant");
        }
    }
}
