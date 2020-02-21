using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientWebsite.Data.Migrations
{
    public partial class AddedRemitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RemitLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    balanceDue = table.Column<double>(nullable: false),
                    paymentDate = table.Column<long>(nullable: false),
                    checkNumber = table.Column<long>(nullable: false),
                    refInvoiceAmount = table.Column<double>(nullable: false),
                    refOrderNumber = table.Column<long>(nullable: false),
                    itemBalanceDue = table.Column<double>(nullable: false),
                    refInvoiceNumber = table.Column<long>(nullable: false),
                    refInvoiceDate = table.Column<long>(nullable: false),
                    refInvoiceDiscAmount = table.Column<double>(nullable: false),
                    refInvoiceAdjNumber = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemitLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RemitLists");
        }
    }
}
