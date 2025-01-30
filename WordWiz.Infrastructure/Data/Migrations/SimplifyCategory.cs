using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WordWiz.Infrastructure.Data.Migrations;

public partial class SimplifyCategory : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Önce mevcut tabloyu yedekleyelim
        migrationBuilder.Sql("CREATE TABLE Categories_Backup AS SELECT Id, Name FROM Categories;");
        
        // Eski tabloyu silelim
        migrationBuilder.DropTable("Categories");
        
        // Yeni tabloyu oluşturalım
        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });
        
        // Yedeklenen verileri geri yükleyelim
        migrationBuilder.Sql("INSERT INTO Categories (Id, Name) SELECT Id, Name FROM Categories_Backup;");
        
        // Yedek tabloyu silelim
        migrationBuilder.Sql("DROP TABLE Categories_Backup;");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Categories");
    }
} 