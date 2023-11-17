using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAppFile.Migrations
{
    /// <inheritdoc />
    public partial class addedParentLink2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "links",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "links");
        }
    }
}
