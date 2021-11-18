using Microsoft.EntityFrameworkCore.Migrations;

namespace H3_CinemaProjektAPI_JB_RFK.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "HallGreat",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "HallSmall",
                table: "Hall");

            migrationBuilder.AddColumn<string>(
                name: "CardType",
                table: "PaymentDetails",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardType",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "isGreatHAll",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "isSmallHall",
                table: "Hall");

            migrationBuilder.AddColumn<int>(
                name: "CardNumber",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HallGreat",
                table: "Hall",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HallSmall",
                table: "Hall",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
