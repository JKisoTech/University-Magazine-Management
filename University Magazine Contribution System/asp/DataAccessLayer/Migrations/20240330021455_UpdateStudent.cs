using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_students_StudentID",
                table: "Contributions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Students_StudentID",
                table: "Contributions",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_LoginName",
                table: "Users",
                column: "LoginName",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Students_StudentID",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_LoginName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_students_StudentID",
                table: "Contributions",
                column: "StudentID",
                principalTable: "students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
