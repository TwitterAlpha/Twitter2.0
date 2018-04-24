using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackUpSystem.Data.Migrations
{
    public partial class TablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetHashtag_Hashtag_HashtagId",
                table: "TweetHashtag");

            migrationBuilder.DropForeignKey(
                name: "FK_TweetHashtag_Tweets_TweetId",
                table: "TweetHashtag");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTweet_Tweets_TweetId",
                table: "UserTweet");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTweet_AspNetUsers_UserId",
                table: "UserTweet");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterAccount_TwitterAccounts_TwitterAccountId",
                table: "UserTwitterAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterAccount_AspNetUsers_UserId",
                table: "UserTwitterAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTwitterAccount",
                table: "UserTwitterAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTweet",
                table: "UserTweet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TweetHashtag",
                table: "TweetHashtag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hashtag",
                table: "Hashtag");

            migrationBuilder.RenameTable(
                name: "UserTwitterAccount",
                newName: "UserTwitterAccounts");

            migrationBuilder.RenameTable(
                name: "UserTweet",
                newName: "UserTweets");

            migrationBuilder.RenameTable(
                name: "TweetHashtag",
                newName: "TweetHashtags");

            migrationBuilder.RenameTable(
                name: "Hashtag",
                newName: "Hashtags");

            migrationBuilder.RenameIndex(
                name: "IX_UserTwitterAccount_TwitterAccountId",
                table: "UserTwitterAccounts",
                newName: "IX_UserTwitterAccounts_TwitterAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTweet_TweetId",
                table: "UserTweets",
                newName: "IX_UserTweets_TweetId");

            migrationBuilder.RenameIndex(
                name: "IX_TweetHashtag_HashtagId",
                table: "TweetHashtags",
                newName: "IX_TweetHashtags_HashtagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTwitterAccounts",
                table: "UserTwitterAccounts",
                columns: new[] { "UserId", "TwitterAccountId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTweets",
                table: "UserTweets",
                columns: new[] { "UserId", "TweetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TweetHashtags",
                table: "TweetHashtags",
                columns: new[] { "TweetId", "HashtagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hashtags",
                table: "Hashtags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetHashtags_Hashtags_HashtagId",
                table: "TweetHashtags",
                column: "HashtagId",
                principalTable: "Hashtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TweetHashtags_Tweets_TweetId",
                table: "TweetHashtags",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTweets_Tweets_TweetId",
                table: "UserTweets",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTweets_AspNetUsers_UserId",
                table: "UserTweets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterAccounts_TwitterAccounts_TwitterAccountId",
                table: "UserTwitterAccounts",
                column: "TwitterAccountId",
                principalTable: "TwitterAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterAccounts_AspNetUsers_UserId",
                table: "UserTwitterAccounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TweetHashtags_Hashtags_HashtagId",
                table: "TweetHashtags");

            migrationBuilder.DropForeignKey(
                name: "FK_TweetHashtags_Tweets_TweetId",
                table: "TweetHashtags");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTweets_Tweets_TweetId",
                table: "UserTweets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTweets_AspNetUsers_UserId",
                table: "UserTweets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterAccounts_TwitterAccounts_TwitterAccountId",
                table: "UserTwitterAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTwitterAccounts_AspNetUsers_UserId",
                table: "UserTwitterAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTwitterAccounts",
                table: "UserTwitterAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTweets",
                table: "UserTweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TweetHashtags",
                table: "TweetHashtags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hashtags",
                table: "Hashtags");

            migrationBuilder.RenameTable(
                name: "UserTwitterAccounts",
                newName: "UserTwitterAccount");

            migrationBuilder.RenameTable(
                name: "UserTweets",
                newName: "UserTweet");

            migrationBuilder.RenameTable(
                name: "TweetHashtags",
                newName: "TweetHashtag");

            migrationBuilder.RenameTable(
                name: "Hashtags",
                newName: "Hashtag");

            migrationBuilder.RenameIndex(
                name: "IX_UserTwitterAccounts_TwitterAccountId",
                table: "UserTwitterAccount",
                newName: "IX_UserTwitterAccount_TwitterAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_UserTweets_TweetId",
                table: "UserTweet",
                newName: "IX_UserTweet_TweetId");

            migrationBuilder.RenameIndex(
                name: "IX_TweetHashtags_HashtagId",
                table: "TweetHashtag",
                newName: "IX_TweetHashtag_HashtagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTwitterAccount",
                table: "UserTwitterAccount",
                columns: new[] { "UserId", "TwitterAccountId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTweet",
                table: "UserTweet",
                columns: new[] { "UserId", "TweetId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TweetHashtag",
                table: "TweetHashtag",
                columns: new[] { "TweetId", "HashtagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hashtag",
                table: "Hashtag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TweetHashtag_Hashtag_HashtagId",
                table: "TweetHashtag",
                column: "HashtagId",
                principalTable: "Hashtag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TweetHashtag_Tweets_TweetId",
                table: "TweetHashtag",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTweet_Tweets_TweetId",
                table: "UserTweet",
                column: "TweetId",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTweet_AspNetUsers_UserId",
                table: "UserTweet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterAccount_TwitterAccounts_TwitterAccountId",
                table: "UserTwitterAccount",
                column: "TwitterAccountId",
                principalTable: "TwitterAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTwitterAccount_AspNetUsers_UserId",
                table: "UserTwitterAccount",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
