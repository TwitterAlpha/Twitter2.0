using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackUpSystem.Data.Migrations
{
    public partial class AddedIsDeletedColumnToUserTwitterAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserTwitterAccounts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserTwitterAccounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserTwitterAccounts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTwitterAccounts");
        }
    }
}
