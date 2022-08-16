using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookinSystemWebApi.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxNumberOfAdults",
                table: "Room",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxNumberOfAdults",
                table: "Room");
        }
    }
}
