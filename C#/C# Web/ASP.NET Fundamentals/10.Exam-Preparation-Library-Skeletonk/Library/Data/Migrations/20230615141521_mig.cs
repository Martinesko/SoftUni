using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace Library.Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_Id",
                table: "IdentityUserBooks");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUserBooks_Id",
                table: "IdentityUserBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IdentityUserBooks");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_CollectorId",
                table: "IdentityUserBooks",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_CollectorId",
                table: "IdentityUserBooks");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "IdentityUserBooks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserBooks_Id",
                table: "IdentityUserBooks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_Id",
                table: "IdentityUserBooks",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
