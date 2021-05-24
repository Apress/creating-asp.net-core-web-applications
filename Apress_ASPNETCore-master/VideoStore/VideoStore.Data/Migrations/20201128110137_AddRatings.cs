using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoStore.Data.Migrations
{
    public partial class AddRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OnlineURL",
                table: "Videos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Videos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Videos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnlineURL",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Videos");
        }
    }
}
