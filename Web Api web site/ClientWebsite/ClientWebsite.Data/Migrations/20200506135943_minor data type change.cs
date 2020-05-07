using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientWebsite.Data.Migrations
{
    public partial class minordatatypechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "refOrderNumber",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "refInvoiceNumber",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "refInvoiceDiscAmount",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "refInvoiceDate",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "refInvoiceAmount",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "refInvoiceAdjNumber",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "paymentDate",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "itemBalanceDue",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "checkNumber",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "balanceDue",
                table: "RemitLists",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<long>(
                name: "PoNumber",
                table: "InvoiceList",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceDate",
                table: "InvoiceList",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<double>(
                name: "InvoiceAmount",
                table: "InvoiceList",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "InvoiceList",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<long>(
                name: "CheckNumber",
                table: "InvoiceList",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<double>(
                name: "CheckAmount",
                table: "InvoiceList",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "ship_date",
                table: "CustomerReport",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "date",
                table: "CustomerReport",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "refOrderNumber",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "refInvoiceNumber",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "refInvoiceDiscAmount",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "refInvoiceDate",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "refInvoiceAmount",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "refInvoiceAdjNumber",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "paymentDate",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "itemBalanceDue",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "checkNumber",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "balanceDue",
                table: "RemitLists",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PoNumber",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceNumber",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "InvoiceDate",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "InvoiceAmount",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CheckNumber",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "CheckAmount",
                table: "InvoiceList",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ship_date",
                table: "CustomerReport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "date",
                table: "CustomerReport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
