using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackUpSystem.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TwitterAccounts_Tweets_CurrentStatusId",
                table: "TwitterAccounts");

            migrationBuilder.DropIndex(
                name: "IX_TwitterAccounts_CurrentStatusId",
                table: "TwitterAccounts");

            migrationBuilder.DropColumn(
                name: "CurrentStatusId",
                table: "TwitterAccounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentStatusId",
                table: "TwitterAccounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TwitterAccounts_CurrentStatusId",
                table: "TwitterAccounts",
                column: "CurrentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TwitterAccounts_Tweets_CurrentStatusId",
                table: "TwitterAccounts",
                column: "CurrentStatusId",
                principalTable: "Tweets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
