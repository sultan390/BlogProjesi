using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Mig_BlogCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID1",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryName",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryID1",
                table: "Categories",
                column: "CategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryID1",
                table: "Categories",
                column: "CategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryID1",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryID1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryID1",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Blogs");
        }
    }
}
