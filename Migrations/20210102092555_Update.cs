using Microsoft.EntityFrameworkCore.Migrations;

namespace Constantin_Mihai_proiect.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Developer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
