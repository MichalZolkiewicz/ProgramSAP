﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramSAP.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CandidatePasswordAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Candidates");
        }
    }
}
