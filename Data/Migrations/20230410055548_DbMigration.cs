using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapInMotion.Data.Migrations
{
    /// <inheritdoc />
    public partial class DbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Station_PrevisionStationStationID",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "PrevisionStationStationID",
                table: "Vehicle",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Station_PrevisionStationStationID",
                table: "Vehicle",
                column: "PrevisionStationStationID",
                principalTable: "Station",
                principalColumn: "StationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Station_PrevisionStationStationID",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "PrevisionStationStationID",
                table: "Vehicle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Station_PrevisionStationStationID",
                table: "Vehicle",
                column: "PrevisionStationStationID",
                principalTable: "Station",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
