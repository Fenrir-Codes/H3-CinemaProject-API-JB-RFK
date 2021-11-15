using Microsoft.EntityFrameworkCore.Migrations;

namespace H3_CinemaProjektAPI_JB_RFK.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallId",
                table: "SeatNumber",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "PaymentDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DirectorsId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Hall",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatNumberId",
                table: "Hall",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SeatNumber_HallId",
                table: "SeatNumber",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_BookingId",
                table: "PaymentDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorsId",
                table: "Movie",
                column: "DirectorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Hall_BookingId",
                table: "Hall",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MovieId",
                table: "Booking",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ProfileId",
                table: "Booking",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Movie_MovieId",
                table: "Booking",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Profile_ProfileId",
                table: "Booking",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hall_Booking_BookingId",
                table: "Hall",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Directors_DirectorsId",
                table: "Movie",
                column: "DirectorsId",
                principalTable: "Directors",
                principalColumn: "DirectorsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Booking_BookingId",
                table: "PaymentDetails",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeatNumber_Hall_HallId",
                table: "SeatNumber",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Movie_MovieId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Profile_ProfileId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Hall_Booking_BookingId",
                table: "Hall");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Directors_DirectorsId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Booking_BookingId",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SeatNumber_Hall_HallId",
                table: "SeatNumber");

            migrationBuilder.DropIndex(
                name: "IX_SeatNumber_HallId",
                table: "SeatNumber");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_BookingId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_Movie_DirectorsId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Hall_BookingId",
                table: "Hall");

            migrationBuilder.DropIndex(
                name: "IX_Booking_MovieId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ProfileId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "HallId",
                table: "SeatNumber");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "DirectorsId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Hall");

            migrationBuilder.DropColumn(
                name: "SeatNumberId",
                table: "Hall");
        }
    }
}
