using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAppFile.Migrations
{

    public partial class InitialMigration2 : Migration
    {
     
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "files",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "files",
                newName: "Id");
        }
    }
}
