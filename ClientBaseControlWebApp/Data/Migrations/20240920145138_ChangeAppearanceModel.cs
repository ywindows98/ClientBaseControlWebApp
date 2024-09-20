using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientBaseControlWebApp.Data.Migrations
{
    public partial class ChangeAppearanceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Appearances_ClientId",
                table: "Appearances");

            migrationBuilder.DropColumn(
                name: "Capillaries",
                table: "Appearances");

            migrationBuilder.DropColumn(
                name: "SkinRedness",
                table: "Appearances");

            migrationBuilder.DropColumn(
                name: "Tan",
                table: "Appearances");

            migrationBuilder.AddColumn<int>(
                name: "AppearanceId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SkinType",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NeedleType",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MembraneColor",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HairColor",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EyeColor",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CirclesUnderEyesColor",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HasCapillaries",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HasTan",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AppearanceId",
                table: "Clients",
                column: "AppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_ClientId",
                table: "Appearances",
                column: "ClientId");

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

            migrationBuilder.DropIndex(
                name: "IX_Clients_AppearanceId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Appearances_ClientId",
                table: "Appearances");

            migrationBuilder.DropColumn(
                name: "AppearanceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CirclesUnderEyesColor",
                table: "Appearances");

            migrationBuilder.DropColumn(
                name: "HasCapillaries",
                table: "Appearances");

            migrationBuilder.DropColumn(
                name: "HasTan",
                table: "Appearances");

            migrationBuilder.AlterColumn<string>(
                name: "SkinType",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NeedleType",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MembraneColor",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HairColor",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EyeColor",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Capillaries",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkinRedness",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tan",
                table: "Appearances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_ClientId",
                table: "Appearances",
                column: "ClientId",
                unique: true);
        }
    }
}
