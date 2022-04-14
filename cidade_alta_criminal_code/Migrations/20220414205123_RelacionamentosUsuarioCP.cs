using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cidade_alta_criminal_code.Migrations
{
    public partial class RelacionamentosUsuarioCP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreateUserId",
                table: "CriminalCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdateUserId",
                table: "CriminalCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CriminalCode_CreateUserId",
                table: "CriminalCode",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CriminalCode_UpdateUserId",
                table: "CriminalCode",
                column: "UpdateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CriminalCode_User_CreateUserId",
                table: "CriminalCode",
                column: "CreateUserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CriminalCode_User_UpdateUserId",
                table: "CriminalCode",
                column: "UpdateUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriminalCode_User_CreateUserId",
                table: "CriminalCode");

            migrationBuilder.DropForeignKey(
                name: "FK_CriminalCode_User_UpdateUserId",
                table: "CriminalCode");

            migrationBuilder.DropIndex(
                name: "IX_CriminalCode_CreateUserId",
                table: "CriminalCode");

            migrationBuilder.DropIndex(
                name: "IX_CriminalCode_UpdateUserId",
                table: "CriminalCode");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "CriminalCode");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "CriminalCode");
        }
    }
}
