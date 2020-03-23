using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookKeeper.Data.Migrations
{
    public partial class midle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultPrice",
                table: "RateDocuments");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "RateDocuments");

            migrationBuilder.DropColumn(
                name: "RateRegisterDate",
                table: "RateDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefaultPrice",
                table: "RateDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "RateDocuments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefaultPrice",
                table: "RateDocuments");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "RateDocuments");

            migrationBuilder.AddColumn<decimal>(
                name: "DefaultPrice",
                table: "RateDocuments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "RateDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RateRegisterDate",
                table: "RateDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
