using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "PasswordHash", "RecordDate", "UserName" },
                values: new object[,]
                {
                    { 2, "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "yildizlar" },
                    { 3, "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "cinar" },
                    { 4, "fcb4864a04e0f5a7f301d4d3d366cf812a30c51dd3fae0d176e1de55294e3c6d", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "user" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "EMail", "RecordDate", "TaxNumber", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "İkitelli OSB Mah. Atatürk Blv. No:45, Başakşehir / İstanbul", "info@yildizlar.com.tr", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "1234567890", "Yıldızlar Elektronik A.Ş.", 2 },
                    { 2, "Güzelyalı Mah. Sahil Cad. No:12, Konak / İzmir", "satis@cinar-gida.com", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "0987654321", "Çınar Gıda Tic. Ltd. Şti.", 3 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceDate", "InvoiceNumber", "RecordDate", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "FTR-2025001", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1470m, 2 },
                    { 2, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "FTR-2025002", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 825m, 3 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceLines",
                columns: new[] { "InvoiceLineId", "InvoiceId", "ItemName", "Price", "Quentity", "RecordDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Samsung 27\" Monitör", 250m, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 2, 1, "Logitech Kablosuz Mouse", 45m, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 3, 2, "Nescafe Classic 100gr", 25m, 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 4, 2, "Doğuş Rize Çayı 1kg", 55m, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3 }
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
                table: "Users",
                keyColumn: "UserId",
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
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
