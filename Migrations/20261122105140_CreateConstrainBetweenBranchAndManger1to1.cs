using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF03.Migrations
{
    /// <inheritdoc />
    public partial class CreateConstrainBetweenBranchAndManger1to1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BranchCode",
                table: "Managers",
                column: "BranchCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchCode",
                table: "Managers",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchCode",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_BranchCode",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "Managers");
        }
    }
}
