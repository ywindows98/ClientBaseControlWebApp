using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientBaseControlWebApp.Data.Migrations
{
    public partial class rebuildAppearance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppearanceId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkinType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasCapillaries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CirclesUnderEyesColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasTan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembraneColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AppearanceId",
                table: "Clients",
                column: "AppearanceId",
                unique: true,
                filter: "[AppearanceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Appearances_AppearanceId",
                table: "Clients",
                column: "AppearanceId",
                principalTable: "Appearances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Appearances_AppearanceId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AppearanceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AppearanceId",
                table: "Clients");
        }
    }
}
