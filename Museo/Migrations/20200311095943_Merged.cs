using Microsoft.EntityFrameworkCore.Migrations;

namespace Museo.Migrations
{
    public partial class Merged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decription",
                table: "IncidenceTypes");

            migrationBuilder.DropColumn(
                name: "Desciption",
                table: "EventTypes");

            migrationBuilder.DropColumn(
                name: "EvenType",
                table: "EventThematics");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IncidenceTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventTypes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thematic",
                table: "EventThematics",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Manager",
                table: "Documents",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DocumentCategories",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "IncidenceTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventTypes");

            migrationBuilder.DropColumn(
                name: "Thematic",
                table: "EventThematics");

            migrationBuilder.AddColumn<string>(
                name: "Decription",
                table: "IncidenceTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desciption",
                table: "EventTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EvenType",
                table: "EventThematics",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Manager",
                table: "Documents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "DocumentCategories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
