using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookinSystemWebApi.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxNumberOfAdults",
                table: "Room",
                newName: "NumberOfAdults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfAdults",
                table: "Room",
                newName: "MaxNumberOfAdults");
        }
    }
}
