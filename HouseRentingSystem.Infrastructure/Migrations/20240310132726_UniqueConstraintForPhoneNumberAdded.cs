using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3d98f35-bfb1-4a0e-8c12-fe87de57d1db", "AQAAAAEAACcQAAAAEJRxfcXYLb9HQ9qVhfvXGGB9udQXvZefZ68x0/CIh6JC+eX16A1VPLMFoRPRtQrdBg==", "2c932d85-90dd-4c30-be0a-586570d9f729" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "917b06b0-0369-4fc3-b50f-6d16a1cc7fd9", "AQAAAAEAACcQAAAAEBI3hlAm1CGa6yENWRUHgLJ1oT0cCU8+vapjSyMl+UTwtofnZ8FmXhyyvGD+RVhJ+A==", "92c3c250-2499-47b6-b507-6a51859cac02" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b203a65c-c44f-4859-bcac-166ce99ba046", "AQAAAAEAACcQAAAAEIGx9dJcbB+XX9IO3nnRN7pUwehY2Zq6a2+JkBcnoN9IwSfbxEEGnSyQjxElAT4glw==", "325d311f-701e-4c3e-b96d-ed672e0a0471" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "134afe86-b87c-4213-9c42-5944befd6709", "AQAAAAEAACcQAAAAEHFGHxaQyDYTq/wkjnnyBtL35KzDV7PburQZFOLX3rYlrMas/S5QiuxmSXIqWkmNjw==", "0dfef3e6-89f6-4865-a8e8-fbe4c3fdef65" });
        }
    }
}
