using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TapInMotion.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Longitude = table.Column<decimal>(type: "decimal(8,5)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8,5)", nullable: false),
                    MapZoom = table.Column<int>(type: "INTEGER", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolID);
                });

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorID);
                    table.ForeignKey(
                        name: "FK_Administrator_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    StationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    BikeCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    ScooterCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    SkateboardCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(8,5)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.StationID);
                    table.ForeignKey(
                        name: "FK_Station_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<string>(type: "TEXT", nullable: false),
                    StudentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Major = table.Column<string>(type: "TEXT", nullable: true),
                    Minor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(8,5)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(8,5)", nullable: false),
                    PreviousStationID = table.Column<int>(type: "INTEGER", nullable: false),
                    PrevisionStationStationID = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentStationID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicle_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Station_CurrentStationID",
                        column: x => x.CurrentStationID,
                        principalTable: "Station",
                        principalColumn: "StationID");
                    table.ForeignKey(
                        name: "FK_Vehicle_Station_PrevisionStationStationID",
                        column: x => x.PrevisionStationStationID,
                        principalTable: "Station",
                        principalColumn: "StationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleID = table.Column<int>(type: "INTEGER", nullable: false),
                    SchoolID = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    StartStationID = table.Column<int>(type: "INTEGER", nullable: false),
                    EndStationID = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_Trip_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "SchoolID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Station_EndStationID",
                        column: x => x.EndStationID,
                        principalTable: "Station",
                        principalColumn: "StationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Station_StartStationID",
                        column: x => x.StartStationID,
                        principalTable: "Station",
                        principalColumn: "StationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_SchoolID",
                table: "Administrator",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Station_SchoolID",
                table: "Station",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolID",
                table: "Student",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserID",
                table: "Student",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_EndStationID",
                table: "Trip",
                column: "EndStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_SchoolID",
                table: "Trip",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_StartStationID",
                table: "Trip",
                column: "StartStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_StudentID",
                table: "Trip",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_VehicleID",
                table: "Trip",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_CurrentStationID",
                table: "Vehicle",
                column: "CurrentStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_PrevisionStationStationID",
                table: "Vehicle",
                column: "PrevisionStationStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SchoolID",
                table: "Vehicle",
                column: "SchoolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
