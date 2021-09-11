using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingTest.Data.Migrations
{
    public partial class loanspecial_interest_rateadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SpecialInterestRate",
                table: "Loans",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialInterestRate",
                table: "Loans");
        }
    }
}
