using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramSAP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRecruiter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "Requisitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Recruiter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recruiter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requisitions_RecruiterId",
                table: "Requisitions",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Recruiter_RecruiterId",
                table: "Requisitions",
                column: "RecruiterId",
                principalTable: "Recruiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Recruiter_RecruiterId",
                table: "Requisitions");

            migrationBuilder.DropTable(
                name: "Recruiter");

            migrationBuilder.DropIndex(
                name: "IX_Requisitions_RecruiterId",
                table: "Requisitions");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Requisitions");
        }
    }
}
