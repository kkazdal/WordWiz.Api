using Microsoft.EntityFrameworkCore.Migrations;
using BCrypt.Net;

public partial class AddUserEntitySeedData : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Admin kullanıcısı ekleyelim (şifre: admin123)
        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "Username", "Email", "PasswordHash", "Role" },
            values: new object[] { 
                1, 
                "admin", 
                "admin@wordwiz.com",
                BCrypt.Net.BCrypt.HashPassword("admin123"),
                "Admin" 
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Users",
            keyColumn: "Id",
            keyValue: 1);
    }
} 