using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ListingDataServiceV1.Migrations
{
    public partial class new_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Listings",
                columns: table => new
                {
                    ListingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listings", x => x.ListingId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdDateTime = table.Column<DateTime>(nullable: false),
                    updatedDateTime = table.Column<DateTime>(nullable: false),
                    createdByUserId = table.Column<long>(nullable: false),
                    updatedByUserId = table.Column<long>(nullable: false),
                    ListingId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    SubcategoryId = table.Column<long>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    sizeTypeId = table.Column<long>(nullable: false),
                    sizeValueId = table.Column<long>(nullable: false),
                    primaryColorId = table.Column<long>(nullable: false),
                    secondaryColorId = table.Column<long>(nullable: false),
                    eraId = table.Column<long>(nullable: false),
                    materialId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "ForeignKey_Item_Listing",
                        column: x => x.ListingId,
                        principalTable: "Listings",
                        principalColumn: "ListingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_attribute",
                columns: table => new
                {
                    itemAttributeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subcategoryAttributeId = table.Column<long>(nullable: true),
                    itemAttributeValue = table.Column<string>(nullable: true),
                    attributeRecommendationId = table.Column<long>(nullable: true),
                    ItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_attribute", x => x.itemAttributeId);
                    table.ForeignKey(
                        name: "ForeignKey_ItemAttribute_Item",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "item_measurement",
                columns: table => new
                {
                    itemMeasurementId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryMeasurementId = table.Column<long>(nullable: false),
                    itemMeasurementValue = table.Column<double>(nullable: false),
                    ItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_measurement", x => x.itemMeasurementId);
                    table.ForeignKey(
                        name: "ForeignKey_ItemMeasurement_Item",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_item_attribute_ItemId",
                table: "item_attribute",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_item_measurement_ItemId",
                table: "item_measurement",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ListingId",
                table: "Items",
                column: "ListingId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "item_attribute");

            migrationBuilder.DropTable(
                name: "item_measurement");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Listings");
        }
    }
}
