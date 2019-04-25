using Microsoft.EntityFrameworkCore.Migrations;

namespace StraussDA.BlogLib.Migrations
{
    public partial class addUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostUrl",
                table: "Post",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostUrl",
                table: "Post");
        }
    }
}
