using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF03.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBankingRelationshipsAndCreateTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOwnerships_accounts_AccountNumber",
                table: "AccountOwnerships");

            migrationBuilder.DropForeignKey(
                name: "FK_accounts_Branches_BranchCode",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchCode",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_BranchCode",
                table: "Managers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "BranchCode",
                table: "Managers");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Customers",
                newName: "DateOfBirth");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_BranchCode",
                table: "Accounts",
                newName: "IX_Accounts_BranchCode");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "AccountNumber");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionNumber);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ManagerId",
                table: "Branches",
                column: "ManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNumber",
                table: "Transactions",
                column: "AccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOwnerships_Accounts_AccountNumber",
                table: "AccountOwnerships",
                column: "AccountNumber",
                principalTable: "Accounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchCode",
                table: "Accounts",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOwnerships_Accounts_AccountNumber",
                table: "AccountOwnerships");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchCode",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Managers_ManagerId",
                table: "Branches");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Branches_ManagerId",
                table: "Branches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Branches");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "accounts");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Customers",
                newName: "BirthDate");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_BranchCode",
                table: "accounts",
                newName: "IX_accounts_BranchCode");

            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "Managers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BranchCode",
                table: "Managers",
                column: "BranchCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOwnerships_accounts_AccountNumber",
                table: "AccountOwnerships",
                column: "AccountNumber",
                principalTable: "accounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_Branches_BranchCode",
                table: "accounts",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchCode",
                table: "Managers",
                column: "BranchCode",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
