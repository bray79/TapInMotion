using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapInMotion.Data.Migrations
{
    /// <inheritdoc />
    public partial class TripDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_School_SchoolID",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Station_EndStationID",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Station_StartStationID",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Student_StudentID",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Vehicle_VehicleID",
                table: "Trip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip",
                table: "Trip");

            migrationBuilder.RenameTable(
                name: "Trip",
                newName: "Trip_1");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_VehicleID",
                table: "Trip_1",
                newName: "IX_Trip_1_VehicleID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_StudentID",
                table: "Trip_1",
                newName: "IX_Trip_1_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_StartStationID",
                table: "Trip_1",
                newName: "IX_Trip_1_StartStationID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_SchoolID",
                table: "Trip_1",
                newName: "IX_Trip_1_SchoolID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_EndStationID",
                table: "Trip_1",
                newName: "IX_Trip_1_EndStationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip_1",
                table: "Trip_1",
                column: "TripID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_1_School_SchoolID",
                table: "Trip_1",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_1_Station_EndStationID",
                table: "Trip_1",
                column: "EndStationID",
                principalTable: "Station",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_1_Station_StartStationID",
                table: "Trip_1",
                column: "StartStationID",
                principalTable: "Station",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_1_Student_StudentID",
                table: "Trip_1",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_1_Vehicle_VehicleID",
                table: "Trip_1",
                column: "VehicleID",
                principalTable: "Vehicle",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_1_School_SchoolID",
                table: "Trip_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_1_Station_EndStationID",
                table: "Trip_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_1_Station_StartStationID",
                table: "Trip_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_1_Student_StudentID",
                table: "Trip_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_1_Vehicle_VehicleID",
                table: "Trip_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trip_1",
                table: "Trip_1");

            migrationBuilder.RenameTable(
                name: "Trip_1",
                newName: "Trip");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_1_VehicleID",
                table: "Trip",
                newName: "IX_Trip_VehicleID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_1_StudentID",
                table: "Trip",
                newName: "IX_Trip_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_1_StartStationID",
                table: "Trip",
                newName: "IX_Trip_StartStationID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_1_SchoolID",
                table: "Trip",
                newName: "IX_Trip_SchoolID");

            migrationBuilder.RenameIndex(
                name: "IX_Trip_1_EndStationID",
                table: "Trip",
                newName: "IX_Trip_EndStationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trip",
                table: "Trip",
                column: "TripID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_School_SchoolID",
                table: "Trip",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "SchoolID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Station_EndStationID",
                table: "Trip",
                column: "EndStationID",
                principalTable: "Station",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Station_StartStationID",
                table: "Trip",
                column: "StartStationID",
                principalTable: "Station",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Student_StudentID",
                table: "Trip",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Vehicle_VehicleID",
                table: "Trip",
                column: "VehicleID",
                principalTable: "Vehicle",
                principalColumn: "VehicleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
