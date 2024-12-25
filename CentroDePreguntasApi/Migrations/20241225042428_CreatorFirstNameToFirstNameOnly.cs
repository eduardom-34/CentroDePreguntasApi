using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroDePreguntasApi.Migrations
{
    /// <inheritdoc />
    public partial class CreatorFirstNameToFirstNameOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatorFirstName",
                table: "Questions",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Questions",
                newName: "CreatorFirstName");
        }
    }
}
