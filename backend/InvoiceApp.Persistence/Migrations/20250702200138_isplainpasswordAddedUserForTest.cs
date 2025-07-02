using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class isplainpasswordAddedUserForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM [InvoiceLines]");
            migrationBuilder.Sql("DELETE FROM [Invoices]");
            migrationBuilder.Sql("DELETE FROM [Customers]");
            migrationBuilder.Sql("DELETE FROM [Users]");

            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlainPassword",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "IsPlainPassword", "PasswordHash", "RecordDate", "UserName" },
                values: new object[,]
                {
                    { 1, true, "parola123", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "yildiz" },
                    { 2, true, "parola123", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "cinar" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "EMail", "RecordDate", "TaxNumber", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "İkitelli OSB Mah. Atatürk Blv. No:45, Başakşehir / İstanbul", "info@yildizlar.com.tr", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "1234567890", "Yıldızlar Elektronik A.Ş.", 1 },
                    { 2, "Güzelyalı Mah. Sahil Cad. No:12, Konak / İzmir", "satis@cinar-gida.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0987654321", "Çınar Gıda Tic. Ltd. Şti.", 2 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceDate", "InvoiceNumber", "RecordDate", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "FTR-2025001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1020m, 1 },
                    { 2, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "FTR-2025002", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 525m, 2 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceLines",
                columns: new[] { "InvoiceLineId", "InvoiceId", "ItemName", "Price", "Quentity", "RecordDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Samsung 27\" Monitör", 250m, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, 1, "Logitech Kablosuz Mouse", 45m, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 3, 2, "Nescafe Classic 100gr", 25m, 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 4, 2, "Doğuş Rize Çayı 1kg", 55m, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceLines",
                keyColumn: "InvoiceLineId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsPlainPassword",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "PasswordHash", "RecordDate", "UserName" },
                values: new object[,]
                {
                    { 5, "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user" },
                    { 6, "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "yildiz" },
                    { 7, "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "cinar" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "EMail", "RecordDate", "TaxNumber", "Title", "UserId" },
                values: new object[,]
                {
                    { 4, "İkitelli OSB Mah. Atatürk Blv. No:45, Başakşehir / İstanbul", "info@yildizlar.com.tr", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "1234567890", "Yıldızlar Elektronik A.Ş.", 6 },
                    { 5, "Güzelyalı Mah. Sahil Cad. No:12, Konak / İzmir", "satis@cinar-gida.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0987654321", "Çınar Gıda Tic. Ltd. Şti.", 7 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceDate", "InvoiceNumber", "RecordDate", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 15, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "FTR-2025001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1020m, 6 },
                    { 16, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "FTR-2025002", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 525m, 7 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceLines",
                columns: new[] { "InvoiceLineId", "InvoiceId", "ItemName", "Price", "Quentity", "RecordDate", "UserId" },
                values: new object[,]
                {
                    { 22, 15, "Samsung 27\" Monitör", 250m, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 23, 15, "Logitech Kablosuz Mouse", 45m, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 24, 16, "Nescafe Classic 100gr", 25m, 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 25, 16, "Doğuş Rize Çayı 1kg", 55m, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 7 }
                });
        }
    }
}
