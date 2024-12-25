using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroDePreguntasApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserNameInAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Answers");
        }
    }
}
