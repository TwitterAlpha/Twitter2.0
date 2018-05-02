using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackUpSystem.Data.Migrations
{
    public partial class ImageUrlAddedToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserImage",
                table: "AspNetUsers",
                newName: "UserImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserImageUrl",
                table: "AspNetUsers",
                newName: "UserImage");
        }
    }
}
