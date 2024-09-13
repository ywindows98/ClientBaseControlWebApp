using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientBaseControlWebApp.Data.Migrations
{
    public partial class AddRelationshipsForProcedureType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcedureType",
                table: "ProcedureRecords");

            migrationBuilder.AddColumn<int>(
                name: "ProcedureTypeId",
                table: "ProcedureRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProcedureType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureRecords_ProcedureTypeId",
                table: "ProcedureRecords",
                column: "ProcedureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureRecords_ProcedureType_ProcedureTypeId",
                table: "ProcedureRecords",
                column: "ProcedureTypeId",
                principalTable: "ProcedureType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureRecords_ProcedureType_ProcedureTypeId",
                table: "ProcedureRecords");

            migrationBuilder.DropTable(
                name: "ProcedureType");

            migrationBuilder.DropIndex(
                name: "IX_ProcedureRecords_ProcedureTypeId",
                table: "ProcedureRecords");

            migrationBuilder.DropColumn(
                name: "ProcedureTypeId",
                table: "ProcedureRecords");

            migrationBuilder.AddColumn<string>(
                name: "ProcedureType",
                table: "ProcedureRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
