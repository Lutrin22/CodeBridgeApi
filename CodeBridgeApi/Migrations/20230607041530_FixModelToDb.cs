using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBridgeApi.Migrations
{
    public partial class FixModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tail_Length",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Jessy",
                columns: new[] { "Tail_Length", "Weight" },
                values: new object[] { "7", "14" });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Neo",
                columns: new[] { "Tail_Length", "Weight" },
                values: new object[] { "22", "32" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Dogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Tail_Length",
                table: "Dogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Jessy",
                columns: new[] { "Tail_Length", "Weight" },
                values: new object[] { 7, 14 });

            migrationBuilder.UpdateData(
                table: "Dogs",
                keyColumn: "Name",
                keyValue: "Neo",
                columns: new[] { "Tail_Length", "Weight" },
                values: new object[] { 22, 32 });
        }
    }
}
