using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientWebsite.Data.Migrations
{
    public partial class SomeModificationdoneonremittable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "refInvoiceAmount",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "refInvoiceAmount",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
