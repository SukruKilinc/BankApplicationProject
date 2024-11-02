using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApplicationProjectDataAccessLayer.Migrations
{
    public partial class mig_add_electric_bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropColumn(
                name: "CustomerAccountID",
                table: "CustomerAccountProcesses");

            migrationBuilder.CreateTable(
                name: "ElectricBills",
                columns: table => new
                {
                    ElectricBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricBills", x => x.ElectricBillID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricBills");

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountID",
                table: "CustomerAccountProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID",
                table: "CustomerAccountProcesses",
                column: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID",
                table: "CustomerAccountProcesses",
                column: "CustomerAccountID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
