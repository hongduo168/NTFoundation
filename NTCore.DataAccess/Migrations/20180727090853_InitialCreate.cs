using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NTCore.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NF_Site",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    AddUserId = table.Column<int>(nullable: false),
                    Copyright = table.Column<string>(maxLength: 255, nullable: false),
                    DataSort = table.Column<int>(nullable: false),
                    DataState = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    LastUpdateUserId = table.Column<int>(nullable: false),
                    LogoUrl = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(maxLength: 255, nullable: false),
                    MetaKeywords = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    SiteState = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NF_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NF_User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    AddUserId = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(maxLength: 255, nullable: false),
                    Confirmed = table.Column<bool>(nullable: false),
                    DataSort = table.Column<int>(nullable: false),
                    DataState = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    IsChecked = table.Column<bool>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    LastUpdateUserId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Nickname = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    SiteId = table.Column<long>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NF_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NF_Site");

            migrationBuilder.DropTable(
                name: "NF_User");
        }
    }
}
