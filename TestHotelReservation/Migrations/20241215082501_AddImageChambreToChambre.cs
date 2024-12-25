using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class AddImageChambreToChambre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageChambre",
                table: "Chambre",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageChambre",
                table: "Chambre");
        }
    }
}
