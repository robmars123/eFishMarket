using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFM.Inventory.Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddInventory : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.EnsureSchema(
            name: "InventoryItems");

        migrationBuilder.CreateTable(
            name: "InventoryItem",
            schema: "InventoryItems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                LastUpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InventoryItem", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "InventoryItem",
            schema: "InventoryItems");
    }
}
