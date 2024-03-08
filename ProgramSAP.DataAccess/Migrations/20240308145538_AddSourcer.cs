using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramSAP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSourcer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Recruiter_RecruiterId",
                table: "Requisitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recruiter",
                table: "Recruiter");

            migrationBuilder.RenameTable(
                name: "Recruiter",
                newName: "Recruiters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recruiters",
                table: "Recruiters",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sourcers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SeniorityLevel = table.Column<int>(type: "int", nullable: false),
                    AreaOfExpertise = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sourcers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequisitionSourcer",
                columns: table => new
                {
                    RequisitionId = table.Column<int>(type: "int", nullable: false),
                    SourcersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitionSourcer", x => new { x.RequisitionId, x.SourcersId });
                    table.ForeignKey(
                        name: "FK_RequisitionSourcer_Requisitions_RequisitionId",
                        column: x => x.RequisitionId,
                        principalTable: "Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequisitionSourcer_Sourcers_SourcersId",
                        column: x => x.SourcersId,
                        principalTable: "Sourcers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequisitionSourcer_SourcersId",
                table: "RequisitionSourcer",
                column: "SourcersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Recruiters_RecruiterId",
                table: "Requisitions",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisitions_Recruiters_RecruiterId",
                table: "Requisitions");

            migrationBuilder.DropTable(
                name: "RequisitionSourcer");

            migrationBuilder.DropTable(
                name: "Sourcers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recruiters",
                table: "Recruiters");

            migrationBuilder.RenameTable(
                name: "Recruiters",
                newName: "Recruiter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recruiter",
                table: "Recruiter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisitions_Recruiter_RecruiterId",
                table: "Requisitions",
                column: "RecruiterId",
                principalTable: "Recruiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
