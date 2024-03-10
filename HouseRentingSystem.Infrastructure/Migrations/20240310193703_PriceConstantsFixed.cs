using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class PriceConstantsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33fa14bb-eac3-4dac-bb5a-57f5a8b554bb", "AQAAAAEAACcQAAAAELyOMMOmlqEcWbPkDTQf7PxDFJ75aiC8X2fzvbAbwehzPz+MHNx+JaxIW89plVx9eA==", "67d72cf0-832d-4ae3-9dd1-1ee9fb718fb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91a1a701-c375-4687-a769-ca486f9adee4", "AQAAAAEAACcQAAAAEKYbkoGOfhYcQ7imASpXeYbCirsx5LFmG8PmHwL8TY2IEcQ3yPFkDqmiGe3fY18ETw==", "ed7b594e-31ef-44f5-8324-b441a7b9f5a9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
