using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MigrationApp.Migrations
{
    /// <inheritdoc />
    public partial class test17 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OfficeName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    OfficeLocation = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    SUN = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MON = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TUE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WED = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    THU = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    FRI = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SAT = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sections_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseName", "Price" },
                values: new object[,]
                {
                    { 1, "Mathmatics", 1000m },
                    { 2, "Physics", 2000m },
                    { 3, "Chemistry", 1500m },
                    { 4, "Biology", 1200m },
                    { 5, "CS-50", 3000m }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "OfficeLocation", "OfficeName" },
                values: new object[,]
                {
                    { 1, "building A", "Off_05" },
                    { 2, "building B", "Off_12" },
                    { 3, "Adminstration", "Off_32" },
                    { 4, "IT Department", "Off_44" },
                    { 5, "IT Department", "Off_43" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "FRI", "MON", "SAT", "SUN", "THU", "TUE", "Title", "WED" },
                values: new object[,]
                {
                    { 1, false, true, false, true, true, true, "Daily", true },
                    { 2, false, false, false, true, true, true, "DayAfterDay", false },
                    { 3, false, true, false, false, false, false, "Twice-a-Week", true },
                    { 4, true, false, true, false, false, false, "Weekend", false },
                    { 5, true, true, true, true, true, true, "Compact", true }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "FName", "LName", "OfficeId" },
                values: new object[,]
                {
                    { 1, "Ahmed", "Abdullah", 1 },
                    { 2, "Yasmeen", "Yasmeen", 2 },
                    { 3, "Khalid", "Hassan", 3 },
                    { 4, "Nadia", "Ali", 4 },
                    { 5, "Ahmed", "Abdullah", 5 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "CourseId", "EndTime", "InstructorId", "ScheduleId", "SectionName", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 10, 0, 0, 0), 1, 1, "S_MA1", new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, 1, new TimeSpan(0, 18, 0, 0, 0), 2, 3, "S_MA2", new TimeSpan(0, 14, 0, 0, 0) },
                    { 3, 2, new TimeSpan(0, 15, 0, 0, 0), 1, 4, "S_PH1", new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, 2, new TimeSpan(0, 12, 0, 0, 0), 3, 1, "S_PH2", new TimeSpan(0, 10, 0, 0, 0) },
                    { 5, 3, new TimeSpan(0, 18, 0, 0, 0), 2, 1, "S_CH1", new TimeSpan(0, 16, 0, 0, 0) },
                    { 6, 3, new TimeSpan(0, 10, 0, 0, 0), 3, 2, "S_CH2", new TimeSpan(0, 8, 0, 0, 0) },
                    { 7, 4, new TimeSpan(0, 14, 0, 0, 0), 4, 3, "S_BI1", new TimeSpan(0, 11, 0, 0, 0) },
                    { 8, 4, new TimeSpan(0, 14, 0, 0, 0), 5, 4, "S_BI2", new TimeSpan(0, 10, 0, 0, 0) },
                    { 9, 5, new TimeSpan(0, 18, 0, 0, 0), 4, 4, "S_CS1", new TimeSpan(0, 16, 0, 0, 0) },
                    { 10, 5, new TimeSpan(0, 15, 0, 0, 0), 5, 3, "S_CS2", new TimeSpan(0, 12, 0, 0, 0) },
                    { 11, 5, new TimeSpan(0, 11, 0, 0, 0), 4, 5, "S_CS3", new TimeSpan(0, 9, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_OfficeId",
                table: "Instructors",
                column: "OfficeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_InstructorId",
                table: "Sections",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ScheduleId",
                table: "Sections",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
