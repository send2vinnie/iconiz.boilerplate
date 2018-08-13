using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconiz.Boilerplate.Migrations
{
    public partial class membermargintop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarginTop",
                table: "IconizTeamMembers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarginTop",
                table: "IconizTeamMembers");
        }
    }
}
