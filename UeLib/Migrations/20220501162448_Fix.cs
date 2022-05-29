using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UeLib.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTag_Assets_AssetsId",
                table: "AssetTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetTag_Tags_TagsId",
                table: "AssetTag");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "AssetTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "AssetsId",
                table: "AssetTag",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetTag_TagsId",
                table: "AssetTag",
                newName: "IX_AssetTag_TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTag_Assets_AssetId",
                table: "AssetTag",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTag_Tags_TagId",
                table: "AssetTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTag_Assets_AssetId",
                table: "AssetTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetTag_Tags_TagId",
                table: "AssetTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "AssetTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "AssetTag",
                newName: "AssetsId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetTag_TagId",
                table: "AssetTag",
                newName: "IX_AssetTag_TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTag_Assets_AssetsId",
                table: "AssetTag",
                column: "AssetsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTag_Tags_TagsId",
                table: "AssetTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
