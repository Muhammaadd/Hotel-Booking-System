using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookinSystemWebApi.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomInfo_RoomTypeId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomInfo",
                table: "RoomInfo");

            migrationBuilder.RenameTable(
                name: "RoomInfo",
                newName: "RoomType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomType",
                table: "RoomType");

            migrationBuilder.RenameTable(
                name: "RoomType",
                newName: "RoomInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomInfo",
                table: "RoomInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_RoomInfo_RoomTypeId",
                table: "Room",
                column: "RoomTypeId",
                principalTable: "RoomInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
