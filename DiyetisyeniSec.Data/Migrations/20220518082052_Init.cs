using Microsoft.EntityFrameworkCore.Migrations;

namespace DiyetisyeniSec.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutritionists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Experience = table.Column<byte>(nullable: false),
                    UniversityName = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    WebsiteURL = table.Column<string>(nullable: true),
                    InstagramUsername = table.Column<string>(nullable: true),
                    WhatsappNumber = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsRemoteEligible = table.Column<bool>(nullable: false),
                    IsEducationConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutritionists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nutritionists");
        }
    }
}
