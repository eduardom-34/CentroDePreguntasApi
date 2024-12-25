using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroDePreguntasApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovedCreatorFromNamesQuestionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatorUserName",
                table: "Questions",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "CreatorLastName",
                table: "Questions",
                newName: "LastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Questions",
                newName: "CreatorUserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Questions",
                newName: "CreatorLastName");
        }
    }
}
