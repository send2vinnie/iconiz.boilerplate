using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconiz.Boilerplate.Migrations
{
    public partial class topic_extern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentStatus",
                table: "IconizTopicComment");

            migrationBuilder.DropColumn(
                name: "CommentStatus",
                table: "IconizTopic");

            migrationBuilder.AddColumn<int>(
                name: "TopicCommentStatus",
                table: "IconizTopicComment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "IconizTopic",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category2",
                table: "IconizTopic",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "IconizTopic",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Raty",
                table: "IconizTopic",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "TopicCommentStatus",
                table: "IconizTopic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IconizTopic_SourceId",
                table: "IconizTopic",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IconizTopic_SourceId",
                table: "IconizTopic");

            migrationBuilder.DropColumn(
                name: "TopicCommentStatus",
                table: "IconizTopicComment");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "IconizTopic");

            migrationBuilder.DropColumn(
                name: "Category2",
                table: "IconizTopic");

            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "IconizTopic");

            migrationBuilder.DropColumn(
                name: "Raty",
                table: "IconizTopic");

            migrationBuilder.DropColumn(
                name: "TopicCommentStatus",
                table: "IconizTopic");

            migrationBuilder.AddColumn<int>(
                name: "CommentStatus",
                table: "IconizTopicComment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentStatus",
                table: "IconizTopic",
                nullable: false,
                defaultValue: 0);
        }
    }
}
