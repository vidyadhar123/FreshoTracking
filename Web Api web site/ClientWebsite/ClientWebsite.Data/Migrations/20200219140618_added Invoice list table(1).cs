using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientWebsite.Data.Migrations
{
    public partial class addedInvoicelisttable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceNumber = table.Column<long>(nullable: false),
                    InvoiceDate = table.Column<long>(nullable: false),
                    InvoiceAmount = table.Column<double>(nullable: false),
                    PoNumber = table.Column<long>(nullable: false),
                    CheckNumber = table.Column<long>(nullable: false),
                    CheckAmount = table.Column<double>(nullable: false),
                    CheckDate = table.Column<string>(nullable: true),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceList", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceList");
        }
    }
}
