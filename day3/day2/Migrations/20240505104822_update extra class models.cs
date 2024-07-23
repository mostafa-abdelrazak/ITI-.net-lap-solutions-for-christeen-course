using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace day2.Migrations
{
    /// <inheritdoc />
    public partial class updateextraclassmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Trainee_Id",
                table: "CrsResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_Trainee_Id",
                table: "CrsResults",
                column: "Trainee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Trainees_Trainee_Id",
                table: "CrsResults",
                column: "Trainee_Id",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Trainees_Trainee_Id",
                table: "CrsResults");

            migrationBuilder.DropIndex(
                name: "IX_CrsResults_Trainee_Id",
                table: "CrsResults");

            migrationBuilder.DropColumn(
                name: "Trainee_Id",
                table: "CrsResults");
        }
    }
}
