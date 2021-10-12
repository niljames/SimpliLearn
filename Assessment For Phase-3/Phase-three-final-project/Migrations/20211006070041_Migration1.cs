using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase_three_final_project.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Description_ProductId",
                table: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Description_ProductId",
                table: "Description",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Description_ProductId",
                table: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Description_ProductId",
                table: "Description",
                column: "ProductId");
        }
    }
}
