using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyDashboardBackend.Migrations
{
    /// <inheritdoc />
    public partial class GradeAndFluentAPi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    addedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.CheckConstraint("CK_Grade_Value", "[Value] IN (2.0, 3.0, 3.5, 4.0, 4.5, 5.0)");
                    table.CheckConstraint("CK_Grade_Weight", "[Weight]>=1 AND [Weight]<=10");
                    table.ForeignKey(
                        name: "FK_Grades_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Course_Credits",
                table: "Courses",
                sql: "[Credits]>=1 AND [Credits]<=10");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Course_Semester",
                table: "Courses",
                sql: "[Semester]>=1 AND [Semester]<=7");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Course_Credits",
                table: "Courses");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Course_Semester",
                table: "Courses");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Courses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldDefaultValue: true);
        }
    }
}
