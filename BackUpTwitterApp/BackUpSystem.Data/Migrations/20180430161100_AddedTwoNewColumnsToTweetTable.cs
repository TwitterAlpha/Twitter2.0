using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackUpSystem.Data.Migrations
{
    public partial class AddedTwoNewColumnsToTweetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserMentioned",
                table: "Tweets",
                newName: "TweetUrl");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Tweets",
                newName: "TweetAuthor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TweetUrl",
                table: "Tweets",
                newName: "UserMentioned");

            migrationBuilder.RenameColumn(
                name: "TweetAuthor",
                table: "Tweets",
                newName: "AuthorId");
        }
    }
}
