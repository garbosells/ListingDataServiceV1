using Microsoft.EntityFrameworkCore.Migrations;

namespace ListingDataServiceV1.Migrations
{
    public partial class full_rep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_item_measurement_ItemId",
                table: "item_measurement");

            migrationBuilder.AlterColumn<long>(
                name: "subcategoryAttributeId",
                table: "item_attribute",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "attributeRecommendationId",
                table: "item_attribute",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "flag",
                table: "item_attribute",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_item_measurement_ItemId",
                table: "item_measurement",
                column: "ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_item_measurement_ItemId",
                table: "item_measurement");

            migrationBuilder.DropColumn(
                name: "flag",
                table: "item_attribute");

            migrationBuilder.AlterColumn<long>(
                name: "subcategoryAttributeId",
                table: "item_attribute",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "attributeRecommendationId",
                table: "item_attribute",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_item_measurement_ItemId",
                table: "item_measurement",
                column: "ItemId");
        }
    }
}
