using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapInMotion.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehiclePreviousStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Station_PrevisionStationStationID",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_PrevisionStationStationID",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "PrevisionStationStationID",
                table: "Vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_PreviousStationID",
                table: "Vehicle",
                column: "PreviousStationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Station_PreviousStationID",
                table: "Vehicle",
                column: "PreviousStationID",
                principalTable: "Station",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Station_PreviousStationID",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_PreviousStationID",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "PrevisionStationStationID",
                table: "Vehicle",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_PrevisionStationStationID",
                table: "Vehicle",
                column: "PrevisionStationStationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Station_PrevisionStationStationID",
                table: "Vehicle",
                column: "PrevisionStationStationID",
                principalTable: "Station",
                principalColumn: "StationID");
        }
    }
}
