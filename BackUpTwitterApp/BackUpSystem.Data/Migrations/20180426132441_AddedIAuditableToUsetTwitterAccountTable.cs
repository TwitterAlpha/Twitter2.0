using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackUpSystem.Data.Migrations
{
    public partial class AddedIAuditableToUsetTwitterAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserTwitterAccounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserTwitterAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserTwitterAccounts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserTwitterAccounts");
        }
    }
}
