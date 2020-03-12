using Microsoft.EntityFrameworkCore.Migrations;

namespace Museo.Migrations
{
    public partial class FloatCostTypeAct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Cost",
                table: "TypeActs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "TypeActs",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
