using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientWebsite.Data.Migrations
{
    public partial class changedtrackingdatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tracking",
                table: "CustomerReport",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "tracking",
                table: "CustomerReport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
