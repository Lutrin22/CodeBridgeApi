using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeBridgeApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tail_Length = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Name", "Color", "Tail_Length", "Weight" },
                values: new object[] { "Jessy", "black & white", 7, 14 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Name", "Color", "Tail_Length", "Weight" },
                values: new object[] { "Neo", "red & amber", 22, 32 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
