using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientWebsite.Data.Migrations
{
    public partial class minordatatypechangesinremitlistfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "refOrderNumber",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "refOrderNumber",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
