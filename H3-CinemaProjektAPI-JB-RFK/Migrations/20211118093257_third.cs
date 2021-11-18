using Microsoft.EntityFrameworkCore.Migrations;

namespace H3_CinemaProjektAPI_JB_RFK.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGreatHAll",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "isSmallHall",
                table: "Hall");

            migrationBuilder.AddColumn<string>(
                name: "HAllName",
                table: "Hall",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HAllName",
                table: "Hall");

            migrationBuilder.AddColumn<bool>(
                name: "isGreatHAll",
                table: "Hall",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSmallHall",
                table: "Hall",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
