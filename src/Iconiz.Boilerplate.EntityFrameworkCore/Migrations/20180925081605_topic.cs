using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Iconiz.Boilerplate.Migrations
{
    public partial class topic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IconizTopic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    SourceId = table.Column<int>(nullable: false),
                    Source = table.Column<string>(maxLength: 50, nullable: true),
                    Url = table.Column<string>(maxLength: 200, nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Summary = table.Column<string>(maxLength: 200, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    Resource = table.Column<string>(maxLength: 50, nullable: true),
                    ResourceUrl = table.Column<string>(maxLength: 200, nullable: true),
                    Author = table.Column<string>(maxLength: 50, nullable: true),
                    Thumbnail = table.Column<string>(maxLength: 200, nullable: true),
                    UpCount = table.Column<int>(nullable: false),
                    DownCount = table.Column<int>(nullable: false),
                    CommitCount = table.Column<int>(nullable: false),
                    ReadCount = table.Column<string>(nullable: true),
                    TopicStatus = table.Column<int>(nullable: false),
                    CommentStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconizTopic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IconizTopicComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<long>(nullable: true),
                    AuthorName = table.Column<string>(maxLength: 50, nullable: true),
                    AuthorIP = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Raty = table.Column<int>(nullable: false),
                    CommentStatus = table.Column<int>(nullable: false),
                    Agent = table.Column<string>(maxLength: 128, nullable: true),
                    Parent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconizTopicComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IconizTopicComment_IconizTopic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "IconizTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IconizTopic_Source_SourceId",
                table: "IconizTopic",
                columns: new[] { "Source", "SourceId" });

            migrationBuilder.CreateIndex(
                name: "IX_IconizTopicComment_TopicId",
                table: "IconizTopicComment",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IconizTopicComment");

            migrationBuilder.DropTable(
                name: "IconizTopic");
        }
    }
}
