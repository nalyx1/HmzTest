using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HmzTest.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1af9ec13-322f-477a-bc92-afa2f767c1f2", null, "Admin", "ADMIN" },
                    { "2bf9ec13-322f-477a-bc92-afa2f767c1f2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3cf9ec13-322f-477a-bc92-afa2f767c1f2", 0, "36b7cf3a-f9a0-4e28-96f4-b48c654a909d", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEHlzbrBIxjJ1SBMpLU22A74ZzfUBzWOHXKMKwND7GIz19mmJpGdcUcJFDiMajdtquQ==", null, false, "67be441e-d398-4b5d-8c5d-ba1dec6e744a", false, "admin" },
                    { "4df9ec13-322f-477a-bc92-afa2f767c1f2", 0, "3083b710-6887-4fc8-954e-5e9cfcd43a2e", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAECwjHLnmSi+OUx2n9h/oMEjAJRDH0WqQCA5W560qzIYJ/pVPBd4aL0KPczwD6+ytQQ==", null, false, "6bdb0f3b-972d-4851-a078-43a29782fdff", false, "user1" },
                    { "5ef9ec13-322f-477a-bc92-afa2f767c1f2", 0, "fdf7bf52-eef9-4c4b-8b30-5d9e5a4fedbe", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEPDHdSyrx8NO78razx8F5RYV4Oemku3odVrVauqyXtwXP6kgl4QUqKtcwQhkKZ0Fxw==", null, false, "c823f741-c414-4629-8e01-88ba08c8c985", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1af9ec13-322f-477a-bc92-afa2f767c1f2", "3cf9ec13-322f-477a-bc92-afa2f767c1f2" },
                    { "2bf9ec13-322f-477a-bc92-afa2f767c1f2", "4df9ec13-322f-477a-bc92-afa2f767c1f2" },
                    { "2bf9ec13-322f-477a-bc92-afa2f767c1f2", "5ef9ec13-322f-477a-bc92-afa2f767c1f2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1af9ec13-322f-477a-bc92-afa2f767c1f2", "3cf9ec13-322f-477a-bc92-afa2f767c1f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bf9ec13-322f-477a-bc92-afa2f767c1f2", "4df9ec13-322f-477a-bc92-afa2f767c1f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2bf9ec13-322f-477a-bc92-afa2f767c1f2", "5ef9ec13-322f-477a-bc92-afa2f767c1f2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1af9ec13-322f-477a-bc92-afa2f767c1f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bf9ec13-322f-477a-bc92-afa2f767c1f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3cf9ec13-322f-477a-bc92-afa2f767c1f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4df9ec13-322f-477a-bc92-afa2f767c1f2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ef9ec13-322f-477a-bc92-afa2f767c1f2");
        }
    }
}
