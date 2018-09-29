using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconiz.Boilerplate.Migrations
{
    public partial class topic_comment_readcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReadCount",
                table: "IconizTopic",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReadCount",
                table: "IconizTopic",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
