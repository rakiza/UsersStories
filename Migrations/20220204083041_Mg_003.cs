using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersStories.Migrations
{
    public partial class Mg_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContextId",
                table: "Stories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contexts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contexts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ContextId",
                table: "Stories",
                column: "ContextId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Contexts_ContextId",
                table: "Stories",
                column: "ContextId",
                principalTable: "Contexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Contexts_ContextId",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Contexts");

            migrationBuilder.DropIndex(
                name: "IX_Stories_ContextId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ContextId",
                table: "Stories");
        }
    }
}
