using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroDePreguntasApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoLasRelacionesConElUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorFirstName",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorLastName",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorUserName",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorFirstName",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatorLastName",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatorUserName",
                table: "Questions");
        }
    }
}
